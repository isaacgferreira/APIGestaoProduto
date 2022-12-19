using System;

namespace Domain.Dtos.Supplier
{
	public class SupplierDtoResponse
	{
		public long Id { get; set; }
		public string Description { get; set; }
		public bool Situation { get; set; }
		public string Cnpj { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
