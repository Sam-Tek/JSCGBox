using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class AdminQuestionController : Controller
    {
        private readonly IQuestionBusiness _questionBusiness;
        private readonly IQuestionnaireBusiness _questionnaireBusiness;
        private readonly UserManager<User> _userManager;

        public AdminQuestionController(UserManager<User> userManager, IQuestionBusiness questionBusiness, IQuestionnaireBusiness questionnaireBusiness)
        {
            _userManager = userManager;
            _questionBusiness = questionBusiness;
            _questionnaireBusiness = questionnaireBusiness;
        }

        // GET: Question/id
        public async Task<IActionResult> Index(int Id = 0)
        {
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(Id, user.Id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            //for create form of creation question
            ViewBag.ModelQuestion = new Question() { QuestionnaireId = questionnaire.Id };
            //for create form of creation proposal
            ViewBag.ModelProposal = new Proposal();

            return View(questionnaire.Questions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Entitled, Timer, QuestionnaireId")] Question question)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(User);
                Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(question.QuestionnaireId, user.Id);
                if (questionnaire == null)
                {
                    return NotFound();
                }
                question.Questionnaire = questionnaire;
                await _questionBusiness.CreateAsync(question);
                return PartialView("_AccordionCard", question);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<bool> Edit(Question question)
        {
            await _questionBusiness.EditAsync(question);
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            Question question = await _questionBusiness.DetailAsync(id);
            if (question is null)
            {
                return false;
            }
            await _questionBusiness.DeleteAsync(question);
            return true;
        }
    }
}