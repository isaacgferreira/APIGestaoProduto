using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		protected readonly DomainContext _contentext;
		private readonly DbSet<T> _dataSet;

		public BaseRepository(DomainContext context)
		{
			_contentext = context;
			_dataSet = _contentext.Set<T>();
		}

		public async Task<bool> DeleteAsync(long id)
		{
			var result = await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
			if (result is null)
				return false;

			_contentext.Remove(result);
			await _contentext.SaveChangesAsync();

			return true;
		}

		public async Task<T> InsertAsync(T entity)
		{

			var result = await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id));
			if (result is null)
				return null;

			_contentext.Remove(result);
			await _contentext.SaveChangesAsync();
			return entity;
		}

		public async Task<T> SelectAsync(long id)
		{
			return await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
		}

		public async Task<IEnumerable<T>> SelectManyAsync()
		{
			return await _dataSet.ToListAsync();
		}

		public async Task<T> UpdateAsync(T entity)
		{
			var result = await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id));
			if (result is null)
				return null;

			entity.UpdateAt = DateTime.Now;

			_contentext.Entry(result).CurrentValues.SetValues(entity);
			await _contentext.SaveChangesAsync();

			return entity;
		}

		public async Task<bool> ExistAsync(long id)
		{
			return await _dataSet.AnyAsync(e => e.Id == id);
		}
	}
}
