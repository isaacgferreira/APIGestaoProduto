using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
	public interface ISupplierService
	{
		Task<Supplier> Get(long id);
		Task<IEnumerable<Supplier>> GetAll();
		Task<Supplier> Post(Supplier supplier);
		Task<Supplier> Put(Supplier supplier);
		Task<bool> Delete(long id);
	}
}
