using Domain.Entities;
using Domain.Interfaces.Services.Produtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
	public class ProductService : IProductService
	{
		public Task<bool> Delete(long id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Product> Get(long id)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Product>> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public Task<Product> Post(Product Product)
		{
			throw new System.NotImplementedException();
		}

		public Task<Product> Put(Product Product)
		{
			throw new System.NotImplementedException();
		}
	}
}
