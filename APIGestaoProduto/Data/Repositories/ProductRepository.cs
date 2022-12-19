using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(DomainContext context) : base(context)
		{
		}

		public async Task<PaginatedListProductModel> GetMany(PaginatedListProductModel pagination)
		{
			IQueryable<Product> query = _context.Set<Product>();

			Expression<Func<Product, bool>> expr = pagination.BuilderFilter();

			var count = await query.Where(expr).CountAsync();
			var items = await query.Where(expr).Skip((pagination.PageIndex - 1) * pagination.PageSize).
				Take(pagination.PageSize).
				OrderBy(p => p.Id).ToListAsync();

			pagination.SetData(items, count);

			return pagination;
		}
	}
}
