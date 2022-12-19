using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
	public class SupplierDtoCreate
	{
		[Required(ErrorMessage = "Descrição do Fornecedor é obrigatório.")]
		[StringLength(100, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
		public string Description { get; set; }
		public bool? Situation { get; set; }
		public string Cnpj { get; set; }
	}
}
