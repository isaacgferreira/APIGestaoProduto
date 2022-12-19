using Domain.Entities;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Model
{
	public class PaginatedListSupplierModel
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage => PageIndex > 1;
		public bool HasNextPage => PageIndex < TotalPages;
		public IEnumerable<Supplier> Data { get; set; }
		public bool FilterCreatedAt { get; set; }
		public DateTime? CreatedAt { get; set; }

		public void SetData(IList<Supplier> items, int count)
		{
			TotalPages = (int)Math.Ceiling(count / (double)PageSize);
			Data = items;
		}

		public Expression<Func<Supplier, bool>> BuilderFilter()
		{
			Expression<Func<Supplier, bool>> expr = PredicateBuilder.New<Supplier>(true);

			if (FilterCreatedAt && CreatedAt is not null)
				expr = expr.And(x => x.CreatedAt >= CreatedAt);

			return expr;
		}
	}
}
