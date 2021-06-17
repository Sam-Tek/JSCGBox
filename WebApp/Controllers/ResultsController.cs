using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly ILogger<ResultController> _logger;
        private readonly IQuestionBusiness _business;
        private readonly IQuestionnaireBusiness _questionnaireBusiness;
        private readonly IResultBusiness _resultBusiness;
        private readonly IProposalBusiness _proposalBusiness;

        public ResultController(ILogger<ResultController> logger, IQuestionBusiness business, IQuestionnaireBusiness questionnaireBusiness, IResultBusiness resultBusiness, IProposalBusiness proposalBusiness)
        {
            _logger = logger;
            _business = business;
            _questionnaireBusiness = questionnaireBusiness;
            _proposalBusiness = proposalBusiness;
            _resultBusiness = resultBusiness;

        }

        public async Task<IActionResult> Index(int id)
        {
            var results = await _resultBusiness.GetResultsAsync();
            return View(results);
        }

        public IActionResult Create(int id)
        {
            var result = new Result();
            return View(result);
        }

        [ActionName("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateResult(Result result, int idq)
        {

            result.Questionnaire = await _questionnaireBusiness.DetailAsync(idq);
            await _resultBusiness.CreateAsync(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _resultBusiness.DetailAsync(id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _resultBusiness.DetailAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Result result)
        {
            await _resultBusiness.EditAsync(result);
            return RedirectToAction("Details");
        }

        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var result = await _resultBusiness.DetailAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _resultBusiness.DeleteAsync(await _resultBusiness.DetailAsync(id));
            return RedirectToAction("Index");
        }
    }
}