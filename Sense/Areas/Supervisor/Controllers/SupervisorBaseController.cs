using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Supervisor.Controllers
{
    [Area("Supervisor")]
    [Authorize(Roles = "Supervisor")]
    [Route("SenseAPI/Supervisor/[controller]/[action]")]
    public class SupervisorBaseController : Controller
    {
 
    }
}
