using Domain.Entities;
using Domain.Model;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<PaginatedListProductModel> GetMany(PaginatedListProductModel pagination);
	}
}
