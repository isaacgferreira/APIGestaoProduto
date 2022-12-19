using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
	public class ProductDtoCreate
	{
		[Required(ErrorMessage = "Descrição do Produto é obrigatório.")]
		[StringLength(100, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
		public string Description { get; set; }

		public DateTime? FabricatedAt { get; set; }

		public DateTime? ExpirationDate { get; set; }

		public long? SupplierId { get; set; }
	}
}
