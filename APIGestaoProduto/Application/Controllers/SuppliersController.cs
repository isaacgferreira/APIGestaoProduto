using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuppliersController : ControllerBase
	{
		private readonly ISupplierService _supplierService;

		public SuppliersController(ISupplierService supplierService)
		{
			_supplierService = supplierService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var suppliers = await _supplierService.GetAll();
			return Ok(suppliers);
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
