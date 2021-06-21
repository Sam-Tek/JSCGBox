using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdminQuestionnaire : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}