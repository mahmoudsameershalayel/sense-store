using Sense.Application;
using Sense.Domain;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense
{
    public class ServicesViewComponent : ViewComponent
    {
        private readonly SenseDbContext _context;

        public ServicesViewComponent(SenseDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var services = _context.ServiceTbls.ToList();
            return View(services);  
        }
    }
}
