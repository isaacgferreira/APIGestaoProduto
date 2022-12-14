using System;

namespace Domain.Entities
{
	public class Produto : BaseEntity
	{
		public string Descricao { get; set; }
		public bool Situacao { get; set; }
		public DateTime Fabricacao { get; set; }
		public DateTime Validade { get; set; }
		public Fornecedor Fornecedor { get; set; }
	}
}
