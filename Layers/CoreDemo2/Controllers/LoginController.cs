using System.Security.Claims;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo2.Controllers
{

	public class LoginController : Controller
	{
        [AllowAnonymous]

        public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		[AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        //public  IActionResult Index(Writer p)
        {
			Context c = new Context();
			var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail
										&& x.WriterPassword == p.WriterPassword);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
				new Claim(ClaimTypes.Name,p.WriterMail)
				};
				var useridentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				//HttpContext.Session.SetString("username", p.WriterMail);
				return RedirectToAction("Index", "Writer");
			}
			else
			{
				return View();
			}

		}
	}
}



