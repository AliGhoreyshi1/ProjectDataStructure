using Microsoft.AspNetCore.Mvc;
using ProjectDataStructure.Models;

namespace ProjectDataStructure.Controllers
{
    public class Project3Controller : Controller
    {
        public Project3Service Project3Service = new Project3Service();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult TestQueueArray(string queueArray)
        {
            TempData["ErrorMessage"] = "";
            try
            {
                ViewBag.IdentityMatrix = Project3Service.TestQueueArray(queueArray);
                ViewBag.queueArray = queueArray;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View("Index");
        }
        public ActionResult TestCircularQueue(string circularQueue)
        {
            TempData["ErrorMessage"] = "";
            try
            {
                ViewBag.IdentityMatrixx = Project3Service.TestCircularQueue(circularQueue);
                ViewBag.circularQueue = circularQueue;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View("Index");
        }
    }
}
