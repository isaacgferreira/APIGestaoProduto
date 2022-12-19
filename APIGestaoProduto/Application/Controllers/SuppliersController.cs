using Domain.Dtos;
using Domain.Dtos.Supplier;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
	[Route("api/suppliers")]
	[ApiController]
	public class SuppliersController : ControllerBase
	{
		private readonly ISupplierService _supplierService;

		public SuppliersController(ISupplierService supplierService)
		{
			_supplierService = supplierService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(PaginatedListSupplierDto paginatedListSupplierDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _supplierService.GetPaginated(paginatedListSupplierDto);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _supplierService.Get(id);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] SupplierDtoCreate supplierDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _supplierService.Post(supplierDto);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] SupplierDtoUpdate supplierDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _supplierService.Put(supplierDto);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeSituation(SupplierDtoSituation supplierDtoSituation)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _supplierService.ChangeSituation(supplierDtoSituation);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}
	}
}
