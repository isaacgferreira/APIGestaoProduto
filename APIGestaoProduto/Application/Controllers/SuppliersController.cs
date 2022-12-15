using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuppliersController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] string value)
		{
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] string value)
		{
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok();
		}
	}
}
