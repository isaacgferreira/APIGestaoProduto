using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		protected readonly DomainContext _context;
		private readonly DbSet<T> _dataSet;

		public BaseRepository(DomainContext context)
		{
			_context = context;
			_dataSet = _context.Set<T>();
		}

		public async Task<bool> DeleteAsync(long id)
		{
			var result = await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
			if (result is null)
				return false;

			_context.Remove(result);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<T> InsertAsync(T entity)
		{
			var result = await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id));

			if (result is not null)
				return null;

			_context.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<T> SelectAsync(long? id)
		{
			return await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
		}

		public async Task<IEnumerable<T>> SelectManyAsync()
		{
			return await _dataSet.AsNoTracking<T>().Skip(0).Take(1).ToListAsync();
			//return await _dataSet.ToListAsync();
		}

		public async Task<T> UpdateAsync(T entity)
		{
			var result = await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id));

			if (result is null)
				return null;

			_context.Entry(result).CurrentValues.SetValues(entity);
			_context.Entry(result).Property(x => x.CreatedAt).IsModified = false;
			await _context.SaveChangesAsync();

			return result;
		}

		public async Task<bool> ExistAsync(long? id)
		{
			return await _dataSet.AnyAsync(e => e.Id == id);
		}

	}
}
