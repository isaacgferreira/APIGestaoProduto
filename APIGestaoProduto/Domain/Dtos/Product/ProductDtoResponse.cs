using System;

namespace Domain.Dtos.Product
{
	public class ProductDtoResponse
	{
		public long Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string Description { get; set; }
		public bool? Situation { get; set; }
		public DateTime? FabricatedAt { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public long? SupplierId { get; set; }
	}
}
