using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo2.Controllers
{

	public class WriterController : Controller
	{
        WriterManager wm = new WriterManager(new EfWriterRepository());
 		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			Context c = new Context();
			var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
			ViewBag.v2 = writerName;
			return View();
		}
	}
}
