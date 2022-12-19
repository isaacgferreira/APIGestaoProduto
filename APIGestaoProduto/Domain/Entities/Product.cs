using System;

namespace Domain.Entities
{
	public class Product : BaseEntity
	{
		public string Description { get; set; }
		public bool Situation { get; set; }
		public DateTime? FabricatedAt { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public long? SupplierId { get; set; }
		public virtual Supplier Supplier { get; set; }
	}
}
