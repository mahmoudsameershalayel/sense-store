using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
	public class ChatController : AdminBaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
