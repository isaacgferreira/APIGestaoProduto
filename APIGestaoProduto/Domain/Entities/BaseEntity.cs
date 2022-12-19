using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public abstract class BaseEntity
	{
		[Key]
		public long Id { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }

		[DefaultValue(true)]
		public bool Situation { get; set; }

	}
}
