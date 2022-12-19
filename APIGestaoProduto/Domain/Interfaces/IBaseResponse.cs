using Domain.Dtos;
using System.Collections.Generic;

namespace Domain.Interfaces
{
	public interface IBaseResponse<T> where T : class
	{
		T Data { get; set; }

		IEnumerable<Errors> Errors { get; set; }

		bool HaveErrors { get; set; }
	}
}
