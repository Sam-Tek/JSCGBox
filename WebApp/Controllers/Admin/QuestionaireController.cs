using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Admin
{
    public class QuestionaireController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}