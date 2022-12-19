using System.Collections.Generic;

namespace Domain.Dtos
{
	public class PaginatedListResponse<T>
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage { get; set; }
		public bool HasNextPage { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
