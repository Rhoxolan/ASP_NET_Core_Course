using _2023._02._01_PW.Models;
using _2023._02._01_PW.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2023._02._01_PW.Controllers
{
	public class HomeController : Controller
	{
		private IRepository<Book> bookRepository;

		public HomeController(IRepository<Book> bookRepository)
		{
			this.bookRepository = bookRepository;
		}

		public IActionResult Index()
		{
			return View(bookRepository.GetAll());
		}

		public IActionResult Details(int id)
		{
			return View(bookRepository.Get(id));
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Book book, IFormFile? cover)
		{
			if (cover is not null)
			{
				using MemoryStream ms = new();
				cover.CopyTo(ms);
				book.Cover = ms.ToArray();
			}
			bookRepository.Add(book);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			return View(bookRepository.Get(id));
		}

		[HttpPost]
		public IActionResult Edit(Book book)
		{
			bookRepository.Edit(book);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			Book? book = bookRepository.Get(id);
			if (book is null)
			{
				return RedirectToAction("Index");
			}
			return View(book);
		}

		[HttpPost]
		[ActionName("Delete")]
		public IActionResult ConfirmDelete(int id)
		{
			bookRepository.Delete(id);
			return RedirectToAction("Index");
		}
	}
}