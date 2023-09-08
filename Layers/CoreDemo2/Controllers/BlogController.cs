using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo2.Controllers
{

    

    public class BlogController : Controller
    {
        

        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

       
        public IActionResult Index()
        {
            var values = bm.GetBlogList();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        
        public IActionResult BlogListByWriter()
        {
            var values = bm.GetBlogListByWriter(1);
            return View(values);
        }


        public IActionResult GetCategoryListByWriter(int id)
        {
            var values = bm.Test(id);
            return View(values);
        }

        [HttpGet]
        

        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                    select new SelectListItem
                                    {
                                        Text = x.CategoryName,
                                        Value = x.CategoryID.ToString()
                                    }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }

        [HttpPost]

        public IActionResult BlogAdd(Blog p)
        {
            p.BlogStatus = true;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = 1;
            bm.TAdd(p);
            return RedirectToAction("BlogListBywriter", "Blog"); 
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues; 
            var blogvalue = bm.TGetById(id);
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            p.WriterID = 1;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }


    }
}
