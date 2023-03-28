using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.CategoryDTOs;

namespace OnlineShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ShopDbContext _context;
		private readonly ILogger<CategoriesController> _logger;

		public CategoriesController(ShopDbContext context, ILogger<CategoriesController> logger)
		{
			_context = context;
			_logger = logger;
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
        public IActionResult Create()
        {
            ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Id");
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
                Category category = new Category
                {
                    Title = categoryDTO.Title,
                    ParentCategoryId = categoryDTO.ParentCategoryId
                };
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
			foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
			{
				_logger.LogError(error.ErrorMessage);
			}
			ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Id", categoryDTO.ParentCategoryId);
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
            ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Id", category.ParentCategoryId);
            //AutoMapper
            EditCategoryDTO categoryDTO = new EditCategoryDTO
            {
                Title= category.Title,
                ParentCategoryId = category.ParentCategoryId
            };
			return View(categoryDTO);
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
                if(category is null)
                {
					return NotFound();
				}
                category.Title = categoryDTO.Title;
                category.ParentCategoryId = categoryDTO.ParentCategoryId;
                _context.Update(category);
                await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Id", categoryDTO.ParentCategoryId);
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

            return View(category);
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
