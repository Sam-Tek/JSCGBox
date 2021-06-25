using System.Linq;
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

            return View(questionnaire.Questions.OrderBy( q => q.Order));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Entitled, Timer, Order, QuestionnaireId")] Question question)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(User);
                Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(question.QuestionnaireId, user.Id);
                if (questionnaire == null)
                {
                    return NotFound();
                }

                //management of the order of questions
                if (question.Order == 0)
                {
                   question.Order = await _questionBusiness.GetNextOrderQuestionAsync(questionnaire);
                }
                else
                {
                    question.Order = await _questionBusiness.OrderExistSoCreateAsync(questionnaire, question);
                }
                question.Questionnaire = questionnaire;
                await _questionBusiness.CreateAsync(question);
                return PartialView("_AccordionCard", question);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Entitled, Timer, Order, QuestionnaireId, Id")] Question question)
        {
            //check if question exist and at the same time I get question from bdd 
            Question questionBDD = await _questionBusiness.DetailAsync(question.Id);
            if (questionBDD == null)
            {
                return NotFound();
            }
            //check if this question belongs to the current user
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaireBdd = await _questionnaireBusiness.DetailByUserIdAsync(question.QuestionnaireId, user.Id);
            if (questionnaireBdd == null)
            {
                return NotFound();
            }
            //management of the order of questions
            if (question.Order == 0)
            {
                question.Order = await _questionBusiness.GetNextOrderQuestionAsync(questionnaireBdd);
            }
            else
            {
                question.Order = await _questionBusiness.OrderExistSoCreateAsync(questionnaireBdd, question);
            }
            //I use this kind of update because it is not possible to have 2 objects tracked on the same question
            questionBDD.Entitled = question.Entitled;
            questionBDD.Timer = question.Timer;
            questionBDD.Order = question.Order;
            await _questionBusiness.EditAsync(questionBDD);

            //I put questionbdd in parameter because question from form does not contain the proposals
            return PartialView("_AccordionCard", questionBDD);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int id = 0)
        {
            //check if question exist 
            Question question = await _questionBusiness.DetailAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            //check if this question belongs to the current user
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(question.QuestionnaireId, user.Id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id = 0)
        {
            //check if question exist 
            Question question = await _questionBusiness.DetailAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            //check if this question belongs to the current user
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(question.QuestionnaireId, user.Id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            await _questionBusiness.DeleteAsync(question);
            
            return RedirectToAction("Index", new { Id = questionnaire.Id});
        }
    }
}