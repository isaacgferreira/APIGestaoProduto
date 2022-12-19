using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Supplier
{
	public class SupplierDtoUpdate
	{
		public long Id { get; set; }

		[Required(ErrorMessage = "Supplier Description is required.")]
		[StringLength(100, ErrorMessage = "Supplier description must be a maximum of {1} characters.")]
		public string Description { get; set; }

		public bool Situation { get; set; }

		public string Cnpj { get; set; }
	}
}
