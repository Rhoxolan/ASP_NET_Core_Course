using _2023._02._01_PW.Models;
using _2023._02._01_PW.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2023._02._01_PW.Controllers
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
			book.Id = CreateId(bookRepository.Books);
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
			Book? book = bookRepository.Books.Find(b => b.Id == id);
			if (book is null)
			{
				return RedirectToAction("Index");
			}
			return View(book);

			//Variant 2
			//int index = bookRepository.Books.FindIndex(b => b.Id == id);
			//if(index == -1)
			//{
			//	return RedirectToAction("Index");
			//}
			//return View(bookRepository.Books[index]);
		}

		[HttpPost]
		[ActionName("Delete")]
		public IActionResult ConfirmDelete(uint id)
		{
			bookRepository.Books.RemoveAt(bookRepository.Books.FindIndex(b => b.Id == id));
			return RedirectToAction("Index");
		}

		private uint CreateId(IEnumerable<Book> books)
		{
			if (!books.Any())
			{
				return 1;
			}
			bool checker = false;
			for (uint i = 1; i < uint.MaxValue; i++)
			{
				foreach (var book in books)
				{
					if (book.Id == i)
					{
						checker = true;
						break;
					}
				}
				if (!checker)
				{
					return i;
				}
				checker = false;
			}
			return default;
		}
	}
}