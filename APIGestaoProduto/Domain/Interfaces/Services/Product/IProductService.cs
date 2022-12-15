using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Produtos
{
	public interface IProductService
	{
		Task<Product> Get(long id);
		Task<IEnumerable<Product>> GetAll();
		Task<Product> Post(Product product);
		Task<Product> Put(Product product);
		Task<bool> Delete(long id);
	}
}
