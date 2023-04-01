using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.CategoryDTOs;
using static System.String;

namespace OnlineShop.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ShopDbContext _context;
		private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        public CategoriesController(ShopDbContext context, ILogger<CategoriesController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
		{
			var shopDbContext = _context.Categories.Include(c => c.ParentCategory);
			return View(await shopDbContext.ToListAsync());
		}

		// GET: Categories/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var category = await _context.Categories
				.Include(c => c.ParentCategory)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		// GET: Categories/Create
		public async Task<IActionResult> Create()
		{
            var categoriesSL = new SelectList(await _context.Categories.ToListAsync(), nameof(Category.Id), nameof(Category.Title));
            ViewData["ParentCategoryId"] = categoriesSL.Prepend(new("Null", Empty));
            return View();
		}

		// POST: Categories/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateCategoryDTO categoryDTO)
		{
			if (ModelState.IsValid)
			{
				Category category = _mapper.Map<Category>(categoryDTO);
				_context.Add(category);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
			{
				_logger.LogError(error.ErrorMessage);
			}
            var categoriesSL = new SelectList(await _context.Categories.ToListAsync(), nameof(Category.Id), nameof(Category.Title));
            ViewData["ParentCategoryId"] = categoriesSL.Prepend(new("Null", Empty));
            return View(categoryDTO);
        }

		// GET: Categories/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}
			var category = await _context.Categories.FindAsync(id);
			if (category == null)
			{
				return NotFound();
			}
            var categoriesSL = new SelectList(await _context.Categories.ToListAsync(), nameof(Category.Id), nameof(Category.Title));
            ViewData["ParentCategoryId"] = categoriesSL.Prepend(new("Null", Empty));
            return View(_mapper.Map<EditCategoryDTO>(category));
		}

		// POST: Categories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditCategoryDTO categoryDTO)
		{
			if (ModelState.IsValid)
			{
				Category? category = await _context.Categories.FindAsync(categoryDTO.Id);
				if (category is null)
				{
					return NotFound();
				}
				category.Title = categoryDTO.Title;
				category.ParentCategoryId = categoryDTO.ParentCategoryId;
				_context.Update(category);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
			{
				_logger.LogError(error.ErrorMessage);
			}
            var categoriesSL = new SelectList(await _context.Categories.ToListAsync(), nameof(Category.Id), nameof(Category.Title));
            ViewData["ParentCategoryId"] = categoriesSL.Prepend(new("Null", Empty));
            return View(categoryDTO);
		}

		// GET: Categories/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}
			var category = await _context.Categories
				.Include(c => c.ParentCategory)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(_mapper.Map<CategoryDTO>(category));
		}

		// POST: Categories/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Categories == null)
			{
				return Problem("Entity set 'ShopDbContext.Categories'  is null.");
			}
			var category = await _context.Categories.FindAsync(id);
			if (category != null)
			{
				_context.Categories.Remove(category);
			}
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CategoryExists(int id)
		{
			return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
