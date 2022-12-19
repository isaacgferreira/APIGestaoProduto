using Domain.Dtos;
using Domain.Dtos.Product;
using Domain.Interfaces.Services.Produtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(PaginatedListProductDto paginatedListProductDto)
		{
			var teste = new ValidationProblemDetails(ModelState);

			//if (!ModelState.IsValid)
			//return BadRequest(ModelState);

			try
			{
				var response = await _productService.GetPaginated(paginatedListProductDto);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(long id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _productService.Get(id);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ProductDtoCreate productDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _productService.Post(productDto);

				if (response.HaveErrors)
					return BadRequest(response);

				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] ProductDtoUpdate productDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _productService.Put(productDto);

				if (response.HaveErrors)
					return BadRequest(response);

				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeSituation([FromBody] ProductDtoSituation productDtoDelete)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				var response = await _productService.ChangeSituation(productDtoDelete);
				return Ok(response);
			}
			catch (ArgumentException ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}
	}
}
