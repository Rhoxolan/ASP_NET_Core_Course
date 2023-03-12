using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigProject.Data.Entities;
using CatsProject.Models.ViewModels.CatViewModels;
using BigProject.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace BigProject.Controllers
{
	public class CatsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly CatContext _context;
		private readonly ILogger _logger;

		public CatsController(CatContext context, ILoggerFactory loggerFactory,
			IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_logger = loggerFactory.CreateLogger<CatsController>();
		}

		// GET: Cats
		public async Task<IActionResult> Index(int breedId, string search)
		{
			IQueryable<Cat> cats = _context.Cats
				.Include(c => c.Breed)
				.Where(t => t.IsDeleted == false);
			if (breedId > 0)
				cats = cats.Where(t => t.BreedId == breedId);
			if (search is not null)
				cats = cats.Where(t => t.CatName.Contains(search));
			IQueryable<Breed> breeds = _context.Breeds;

			SelectList breedSL = new(await breeds.ToListAsync(),
				dataValueField: nameof(Breed.Id),
				dataTextField: nameof(Breed.BreedName),
				selectedValue: breedId);

			IEnumerable<CatDTO> tempCats = _mapper.Map<IEnumerable<CatDTO>>(await cats.ToListAsync());

			//mapping Cat to CatDTO
			//var tempCats = await cats
			//    .Select(t => new CatDTO
			//    {
			//        Id = t.Id,
			//        CatName = t.CatName,
			//        Description = t.Description,
			//        IsVacinated = t.IsVacinated,
			//        Gender = t.Gender,
			//        BreedId = t.BreedId,
			//        Image = t.Image,
			//        Breed = new BreedDTO
			//        {
			//            Id = t.Breed.Id,
			//            BreedName = t.Breed.BreedName
			//        }
			//    }).ToListAsync();

			IndexCatViewModel vm = new IndexCatViewModel
			{
				Cats = tempCats,
				BreedSl = breedSL,
				BreedId = breedId,
				Search = search
			};

			return View(vm);
		}

		// GET: Cats/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Cats == null)
			{
				return NotFound();
			}

			var cat = await _context.Cats
				.Include(c => c.Breed)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (cat == null)
			{
				return NotFound();
			}
			DetailsCatViewModel vM = new DetailsCatViewModel
			{
				Cat = cat
			};
			return View(vM);
		}

		// GET: Cats/Create
		public IActionResult Create()
		{
			//ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "BreedName");
			//ViewData["CatGender"] = new SelectList(Enum.GetValues(typeof(CatGender)));
			CreateCatViewModel createCatViewModel = new CreateCatViewModel
			{
				BreedSL = new SelectList(_context.Breeds, "Id", "BreedName")
			};
			return View(createCatViewModel);
		}

		// POST: Cats/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("Id,CatName,Description,Gender,IsVacinated,Image,BreedId")] Cat cat)
		public async Task<IActionResult> Create(CreateCatViewModel newCat)
		{
            if (!ModelState.IsValid)
			{
				SelectList breedSL = new SelectList(await _context.Breeds.ToListAsync(),
					nameof(Breed.Id),
					nameof(Breed.BreedName),
					newCat.Cat.BreedId);
				newCat.BreedSL = breedSL;
				foreach (var key in ModelState.Keys)
					_logger.LogInformation(key);
				foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
					_logger.LogError(error.ErrorMessage);
				return View(newCat);
			}
			//ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "BreedName", cat.BreedId);
			byte[] buff = null!;
			using(BinaryReader br = new BinaryReader(newCat.Image.OpenReadStream()))
			{
				newCat.Cat.Image = br.ReadBytes((int)newCat.Image.Length);
			}
			Cat createdCat = _mapper.Map<Cat>(newCat.Cat);
			_context.Add(createdCat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

		// GET: Cats/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Cats == null)
			{
				return NotFound();
			}

			var cat = await _context.Cats.FindAsync(id);
			if (cat == null)
			{
				return NotFound();
			}
			ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "BreedName", cat.BreedId);
			return View(cat);
		}

		// POST: Cats/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,CatName,Description,Gender,IsVacinated,Image,IsDeleted,BreedId")] Cat cat)
		{
			if (id != cat.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(cat);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CatExists(cat.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "BreedName", cat.BreedId);
			return View(cat);
		}

		// GET: Cats/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Cats == null)
			{
				return NotFound();
			}

			var cat = await _context.Cats
				.Include(c => c.Breed)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (cat == null)
			{
				return NotFound();
			}

			return View(cat);
		}

		// POST: Cats/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Cats == null)
			{
				return Problem("Entity set 'CatContext.Cats'  is null.");
			}
			var cat = await _context.Cats.FindAsync(id);
			if (cat != null)
			{
				_context.Cats.Remove(cat);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CatExists(int id)
		{
			return _context.Cats.Any(e => e.Id == id);
		}
    }
}
