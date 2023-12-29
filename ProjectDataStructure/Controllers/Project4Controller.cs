using Microsoft.AspNetCore.Mvc;
using ProjectDataStructure.Models;

namespace ProjectDataStructure.Controllers
{
    public class Project4Controller : Controller
    {
        Project4Service project4Service = new Project4Service();
        public IActionResult Index()
        {
            return View();
        }
    }
}
