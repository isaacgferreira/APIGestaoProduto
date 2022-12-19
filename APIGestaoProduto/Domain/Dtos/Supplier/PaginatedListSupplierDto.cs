using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Supplier
{
	public class PaginatedListSupplierDto
	{
		[Required(ErrorMessage = "Required page index.")]
		public int PageIndex { get; set; }

		[Required(ErrorMessage = "Required page size.")]
		public int PageSize { get; set; }

		public bool FilterCreatedAt { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
}
