using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IServiceRepository
	{
		Task<IEnumerable<ServiceTbl>> GetAllServicesAsync();
		void CreateService(ServiceTbl service);
		void UpdateService(ServiceTbl service);
		void DeleteService(ServiceTbl service);
		Task<ServiceTbl> GetServiceByIdAsync(int id);
	}
}
