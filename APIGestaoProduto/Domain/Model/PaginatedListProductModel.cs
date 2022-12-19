using Domain.Entities;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Model
{
	public class PaginatedListProductModel
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage => PageIndex > 1;
		public bool HasNextPage => PageIndex < TotalPages;
		public IEnumerable<Product> Data { get; set; }
		public bool FilterFabricatedAt { get; set; }
		public DateTime? FabricatedAt { get; set; }
		public bool FilterExpirationDate { get; set; }
		public DateTime? ExpirationDate { get; set; }

		public void SetData(IList<Product> items, int count)
		{
			TotalPages = (int)Math.Ceiling(count / (double)PageSize);
			Data = items;
		}

		public Expression<Func<Product, bool>> BuilderFilter()
		{
			Expression<Func<Product, bool>> expr = PredicateBuilder.New<Product>(true);

			if (FilterFabricatedAt && FabricatedAt is not null)
				expr = expr.And(x => x.FabricatedAt >= FabricatedAt);

			if (FilterExpirationDate && ExpirationDate is not null)
				expr = expr.And(x => x.ExpirationDate >= ExpirationDate);

			return expr;
		}
	}
}
