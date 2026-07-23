using Sense.Application.BannerRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.ServiceRepositories
{
	public class ServiceRepository : RepositoryBase<ServiceTbl>, IServiceRepository
	{
		public ServiceRepository(SenseDbContext context) : base(context)
		{
		}

		public void CreateService(ServiceTbl service)
			=> Create(service);
		

		public void DeleteService(ServiceTbl service)
			=> Delete(service);


		public async Task<IEnumerable<ServiceTbl>> GetAllServicesAsync()
			=> await FindAll().ToListAsync();


		public async Task<ServiceTbl> GetServiceByIdAsync(int id)
			=> await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
	

		public void UpdateService(ServiceTbl service)
			=> Update(service);
		
	}
}
