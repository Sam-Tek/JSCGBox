using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class QuestionnaireController : Controller
    {
        // GET
        public IActionResult Index()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
    }
}