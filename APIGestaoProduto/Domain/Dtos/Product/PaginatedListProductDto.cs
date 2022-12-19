using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
	public class PaginatedListProductDto
	{
		[Required(ErrorMessage = "Required page index.")]
		[Range(1, 20)]
		public int PageIndex { get; set; }

		[Required(ErrorMessage = "Required page size.")]
		[Range(1, 100)]
		public int PageSize { get; set; }

		public bool FilterFabricatedAt { get; set; }

		public DateTime? FabricatedAt { get; set; }

		public bool FilterExpirationDate { get; set; }

		public DateTime? ExpirationDate { get; set; }
	}
}
