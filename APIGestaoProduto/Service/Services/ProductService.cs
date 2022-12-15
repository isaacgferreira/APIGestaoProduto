using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Produtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
	public class ProductService : IProductService
	{
		private readonly IRepository<Product> _repository;

		public ProductService(IRepository<Product> repository)
		{
			_repository = repository;
		}

		public Task<bool> Delete(long id)
		{
			return _repository.DeleteAsync(id);
		}

		public Task<Product> Get(long id)
		{
			return _repository.SelectAsync(id);
		}

		public Task<IEnumerable<Product>> GetAll()
		{
			return _repository.SelectManyAsync();
		}

		public Task<Product> Post(Product product)
		{
			return _repository.InsertAsync(product);
		}

		public Task<Product> Put(Product product)
		{
			return _repository.UpdateAsync(product);
		}
	}
}
