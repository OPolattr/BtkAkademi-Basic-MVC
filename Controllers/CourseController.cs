using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }
        [HttpGet]//default
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //bilgiler formdan gelecek
        public IActionResult Apply([FromForm] Candidate model)
        {
            if(Repository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("","There is already an applications for you.");   
            }

            if(ModelState.IsValid)
            {
                Repository.Add(model);
                return View("Feedback",model);      
            }
            return View();
        }
    }
}