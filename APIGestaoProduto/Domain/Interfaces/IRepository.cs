using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<T> InsertAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<bool> DeleteAsync(long id);
		Task<T> SelectAsync(long? id);
		Task<IEnumerable<T>> SelectManyAsync();
		Task<bool> ExistAsync(long? id);
	}
}
