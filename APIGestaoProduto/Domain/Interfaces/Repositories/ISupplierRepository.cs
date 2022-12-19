using Domain.Entities;
using Domain.Model;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
	public interface ISupplierRepository : IRepository<Supplier>
	{
		Task<PaginatedListSupplierModel> GetMany(PaginatedListSupplierModel pagination);
	}
}
