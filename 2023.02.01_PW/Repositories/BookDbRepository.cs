using _2023._02._01_PW.Contexts;
using _2023._02._01_PW.Models;
using System.Reflection;

namespace _2023._02._01_PW.Repositories
{
	public class BookDbRepository : IRepository<Book>
	{
		private ApplicationContext _context;

		public BookDbRepository(ApplicationContext context)
		{
			_context = context;
		}

		public void Add(Book book)
		{
			_context.Books.Add(book);
			_context.SaveChanges();
		}

		public bool Delete(int id)
		{
			Book? book = _context.Books.Find(id);
			if(book == null)
			{
				return false;
			}
			_context.Books.Remove(book);
			_context.SaveChanges();
			return true;
		}

		public bool Edit(Book book)
		{
			Book? editingBook = _context.Books.Find(book.Id);
			if(editingBook is not null)
			{
				PropertyInfo[] properties = typeof(Book).GetProperties();
				foreach(PropertyInfo property in properties)
				{
					property.SetValue(editingBook, property.GetValue(book));
				}
				_context.Entry(editingBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				_context.SaveChanges();
				return true;
			}
			return false;
		}

		public Book? Get(int id)
		{
			return _context.Books.ToList().Find(b => b.Id == id);
		}

		public ICollection<Book> GetAll()
		{
			return _context.Books.ToList();
		}
	}
}
