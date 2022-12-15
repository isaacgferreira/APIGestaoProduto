namespace Domain.Entities
{
	public class Supplier : BaseEntity
	{
		public string Description { get; set; }
		public string Cnpj { get; set; }
		public Product Product { get; set; }
	}
}
