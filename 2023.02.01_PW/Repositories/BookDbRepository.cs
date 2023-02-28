using _2023._02._01_PW.Contexts;
using _2023._02._01_PW.Models;

namespace _2023._02._01_PW.Repositories
{
	public class BookDbRepository : IRepository<Book>
	{
		private ApplicationContext _context;

		public BookDbRepository(ApplicationContext context)
		{
			_context = context;
		}

		public void Add(Book entity)
		{
			_context.Books.Add(entity);
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

		public void Edit(Book entity)
		{
			_context.SaveChanges();
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
