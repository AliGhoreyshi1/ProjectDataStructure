using Microsoft.AspNetCore.Mvc;
using ProjectDataStructure.Models;

namespace ProjectDataStructure.Controllers
{
    public class Project2Controller : Controller
    {
        public Project2Service Project2Service = new Project2Service();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Matrix(string Numdiscs)
        {
            TempData["ErrorMessage"] = "";
            try
            {
                ViewBag.IdentityMatrix = Project2Service.GenerateIdentityMatrix(Numdiscs);
                ViewBag.Numdiscs = Numdiscs;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View("Index");
        }
    }
}
