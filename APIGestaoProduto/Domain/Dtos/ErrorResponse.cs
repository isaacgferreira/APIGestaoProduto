using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Domain.Dtos
{
	public class ErrorResponse
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IEnumerable<Errors> Errors { get; set; }

		[JsonIgnore]
		public bool HaveErrors => this.Errors != null && this.Errors.Any();
	}
}
