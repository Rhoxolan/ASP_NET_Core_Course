namespace _2023._02._01_PW.Repositories
{
	public interface IRepository<T>
	{
		ICollection<T> GetAll();

		void Add(T entity);

		T? Get(int id);

		void Edit(T entity);

		bool Delete(int id);
	}
}
