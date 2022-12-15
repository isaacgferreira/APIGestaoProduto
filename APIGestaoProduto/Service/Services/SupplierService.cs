using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
	public class SupplierService : ISupplierService
	{
		public Task<bool> Delete(long id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Supplier> Get(long id)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Supplier>> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public Task<Supplier> Post(Supplier supplier)
		{
			throw new System.NotImplementedException();
		}

		public Task<Supplier> Put(Supplier supplier)
		{
			throw new System.NotImplementedException();
		}
	}
}
