using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo2.Controllers
{
	public class AccessDeniedController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
