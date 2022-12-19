using System.Text.Json.Serialization;

namespace Domain.Dtos
{
	public class BaseResponse<T> : ErrorResponse where T : class
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public T Data { get; set; }
	}
}
