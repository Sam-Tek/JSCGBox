using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionBusiness _business;
        private readonly IQuestionnaireBusiness _questionnaireBusiness;

        public QuestionController(ILogger<QuestionController> logger, IQuestionBusiness business, IQuestionnaireBusiness questionnaireBusiness)
        {
            _logger = logger;
            _business = business;
            _questionnaireBusiness = questionnaireBusiness;
        }

        public async Task<IActionResult> Index(int id)
        {
            var questions = await _business.GetQuestionsAsync();
            return View(questions);
        }

        public IActionResult Create(int id)
        {
            var question = new Question();
            return View(question);
        }

        [ActionName("Create")]
        public async Task<IActionResult> CreateResult(Question question, int id)
        {
            question.Questionnaire = await _questionnaireBusiness.DetailAsync(id);
            await _business.CreateAsync(question);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _business.DetailAsync(id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _business.DetailAsync(id));
        }

        public async Task<IActionResult> Edit(Question question)
        {
            await _business.EditAsync(question);
            return RedirectToAction("Details");
        }

        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var question = await _business.DetailAsync(id);
            return View(question);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _business.DeleteAsync(await _business.DetailAsync(id));
            return RedirectToAction("Index");
        }
    }
}