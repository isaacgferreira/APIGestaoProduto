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
	public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
	{
		public SupplierRepository(DomainContext context) : base(context)
		{
		}

		public async Task<PaginatedListSupplierModel> GetMany(PaginatedListSupplierModel pagination)
		{
			IQueryable<Supplier> query = _context.Set<Supplier>();
			Expression<Func<Supplier, bool>> expr = pagination.BuilderFilter();

			var count = await query.Where(expr).CountAsync();
			var items = await query.Where(expr).Skip((pagination.PageIndex - 1) * pagination.PageSize).
				Take(pagination.PageSize).
				OrderBy(p => p.Id).ToListAsync();

			pagination.SetData(items, count);

			return pagination;
		}
	}
}
