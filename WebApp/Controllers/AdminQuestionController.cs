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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Entitled, Timer, QuestionnaireId, Id")] Question question)
        {
            //check if question exist 
            if (!await _questionBusiness.ExistAsync(question.Id))
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

            await _questionBusiness.EditAsync(question);
            return PartialView("_AccordionCard", question);
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