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
using OnlineShop.Models.DTO.PhotoDTOs;

namespace OnlineShop.Controllers
{
    [Authorize(Policy = "ApplicationPolicy")]
    public class PhotosController : Controller
    {
        private readonly ShopDbContext _context;
		private readonly ILogger<PhotosController> _logger;
        private readonly IMapper _mapper;

		public PhotosController(ShopDbContext context, ILogger<PhotosController> logger, IMapper mapper)
		{
			_context = context;
			_logger = logger;
            _mapper = mapper;
		}

		// GET: Photos
		public async Task<IActionResult> Index()
        {
            var shopDbContext = _context.Photos.Include(p => p.Product);
            return View(await shopDbContext.ToListAsync());
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, nameof(Product.Id), nameof(Product.Title));
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePhotoDTO photoDTO)
        {
            if (ModelState.IsValid)
            {
                Photo photo = _mapper.Map<Photo>(photoDTO);
                _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
			foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
			{
				_logger.LogError(error.ErrorMessage);
			}
			ViewData["ProductId"] = new SelectList(_context.Products, nameof(Product.Id), nameof(Product.Title), photoDTO.ProductId);
            return View(photoDTO);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
			ViewData["ProductId"] = new SelectList(_context.Products, nameof(Product.Id), nameof(Product.Title), photo.ProductId);
            return View(_mapper.Map<EditPhotoDTO>(photo));
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPhotoDTO photoDTO)
        {
            if (ModelState.IsValid)
            {
                Photo? photo = await _context.Photos.FindAsync(photoDTO.Id);
				if (photo is null)
				{
					return NotFound();
				}
                photo.FileName = photoDTO.FileName;
                photo.PhotoUrl = photoDTO.PhotoUrl;
                photo.ProductId = photoDTO.ProductId;
                _context.Update(photo);
                await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
            }
			foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
			{
				_logger.LogError(error.ErrorMessage);
			}
			ViewData["ProductId"] = new SelectList(_context.Products, nameof(Product.Id), nameof(Product.Title), photoDTO.ProductId);
            return View(photoDTO);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }
            var photo = await _context.Photos
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<PhotoDTO>(photo));
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Photos == null)
            {
                return Problem("Entity set 'ShopDbContext.Photos'  is null.");
            }
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(int id)
        {
          return (_context.Photos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
