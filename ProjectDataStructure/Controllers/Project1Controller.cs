using Microsoft.AspNetCore.Mvc;
using ProjectDataStructure.Models;

namespace ProjectDataStructure.Controllers
{
    public class Project1Controller : Controller
    {
        Project1Service project1Service = new Project1Service();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult TowerOfHanoi(int Numdiscs)
        {
            TempData["ErrorMessage"] = "";
            try
            {
                ViewBag.resultTower = project1Service.GetTower(Numdiscs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View("Index");
        }
        public ActionResult Exponent(long Number, int Exponent)
        {
            TempData["ErrorMessage"] = "";
            try
            {
                ViewBag.Exponent = long.Parse(project1Service.GetExponent(Number, Exponent));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View("Index");
        }
        public ActionResult CombinationFunction(int FirstNumber, int SecondNumber)
        {
            TempData["ErrorMessage"] = "";
            try
            {
                ViewBag.Result = long.Parse(project1Service.GetCombinationFunction(FirstNumber, SecondNumber));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View("Index");
        }
    }
}
