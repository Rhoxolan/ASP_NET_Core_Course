using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.ProductDTOs;

namespace OnlineShop.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ProductsController : Controller
	{
		private readonly ShopDbContext _context;
		private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public ProductsController(ShopDbContext context, ILogger<HomeController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: Products
        public async Task<IActionResult> Index()
		{
			var shopDbContext = _context.Products.Include(p => p.Category);
			return View(await shopDbContext.ToListAsync());
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Products/Create
		public IActionResult Create()
		{
			ViewData["CategoryId"] = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Title));
			return View();
		}

		// POST: Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateProductDTO productDTO)
		{
			if (ModelState.IsValid)
			{
				Product product = _mapper.Map<Product>(productDTO);
				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
			{
				_logger.LogError(error.ErrorMessage);
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Title), productDTO.CategoryId);
			return View(productDTO);
		}

		// GET: Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}
			var product = await _context.Products.FindAsync(id);
			if (product is null)
			{
				return NotFound();
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Title), product.CategoryId);
			return View(_mapper.Map<EditProductDTO>(product));
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditProductDTO productDTO)
		{
			if (ModelState.IsValid)
			{
				Product? product = await _context.Products.FindAsync(productDTO.Id);
				if (product is null)
				{
					return NotFound();
				}
				product.Title = productDTO.Title;
				product.Price = productDTO.Price;
				product.CategoryId = productDTO.CategoryId;
				product.Count = productDTO.Count;
				_context.Update(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
			{
				_logger.LogError(error.ErrorMessage);
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Title), productDTO.CategoryId);
			return View(productDTO);
		}

		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}
			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return View(_mapper.Map<ProductDTO>(product));
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Products == null)
			{
				return Problem("Entity set 'ShopDbContext.Products'  is null.");
			}
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				_context.Products.Remove(product);
			}
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(int id)
		{
			return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
