using _2023._01._30_PW.Models;
using _2023._01._30_PW.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2023._01._30_PW.Controllers
{
	public class HomeController : Controller
	{
		private BookRepository bookRepository;

		public HomeController(BookRepository bookRepository)
		{
			this.bookRepository = bookRepository;
		}

		public IActionResult Index()
		{
			return View(bookRepository.Books);
		}

		public IActionResult Details(uint id)
		{
			return View(bookRepository.Books.Where(b => b.Id == id).FirstOrDefault());
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
		public IActionResult Add(Book book)
		{
			uint maxIdFromTheCollection = bookRepository.Books.Max(b => b.Id);
			book.Id = ++maxIdFromTheCollection;
			bookRepository.Books.Add(book);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(uint id)
		{
			return View(bookRepository.Books.Where(b => b.Id == id).First());
		}

		[HttpPost]
		public IActionResult Edit(Book book)
		{
			bookRepository.Books[bookRepository.Books.FindIndex(b => b.Id == book.Id)] = book;
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(uint id)
		{
			return View(bookRepository.Books.Where(b => b.Id == id).First());
		}

		[HttpPost]
		[ActionName("Delete")]
		public IActionResult ConfirmDelete(uint id)
		{
			bookRepository.Books.RemoveAt(bookRepository.Books.FindIndex(b => b.Id == id));
			return RedirectToAction("Index");
		}
	}
}