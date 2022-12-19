using System.Collections.Generic;

namespace Domain.Entities
{
	public class Supplier : BaseEntity
	{
		public string Description { get; set; }
		public bool Situation { get; set; }
		public string Cnpj { get; set; }
		public virtual IList<Product> Products { get; set; }
	}
}
