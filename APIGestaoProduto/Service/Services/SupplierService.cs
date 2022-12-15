using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
	public class SupplierService : ISupplierService
	{
		private readonly IRepository<Supplier> _repository;

		public SupplierService(IRepository<Supplier> repository)
		{
			_repository = repository;
		}

		public Task<bool> Delete(long id)
		{
			return _repository.DeleteAsync(id);
		}

		public Task<Supplier> Get(long id)
		{
			return _repository.SelectAsync(id);
		}

		public Task<IEnumerable<Supplier>> GetAll()
		{
			return _repository.SelectManyAsync();
		}

		public Task<Supplier> Post(Supplier supplier)
		{
			return _repository.InsertAsync(supplier);
		}

		public Task<Supplier> Put(Supplier supplier)
		{
			return _repository.UpdateAsync(supplier);
		}
	}
}
