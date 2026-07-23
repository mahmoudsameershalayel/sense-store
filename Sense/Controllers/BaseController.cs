using Sense.Application;
using Sense.Domain;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sense.Controllers
{
    public class BaseController : Controller
    {
        private readonly SenseDbContext _context;
        public BaseController(SenseDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var services = _context.ServiceTbls.ToList();
            ViewBag.Services = services;
        }
    }
}
