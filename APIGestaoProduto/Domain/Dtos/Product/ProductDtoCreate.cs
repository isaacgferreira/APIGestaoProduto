using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
	public class ProductDtoCreate
	{
		[Required(ErrorMessage = "Product Description is required.")]
		[StringLength(100, ErrorMessage = "Product description must be a maximum of {1} characters.")]
		public string Description { get; set; }

		public DateTime? FabricatedAt { get; set; }

		public DateTime? ExpirationDate { get; set; }

		public long? SupplierId { get; set; }
	}
}
