using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class AdminProposalController : Controller
    {
        private IProposalBusiness _proposalBusiness;
        private IQuestionBusiness _questionBusiness;
        private IQuestionnaireBusiness _questionnaireBusiness;
        private UserManager<User> _userManager;
        public AdminProposalController(UserManager<User> userManager, IProposalBusiness proposalBusiness, IQuestionBusiness questionBusiness, IQuestionnaireBusiness questionnaireBusiness)
        {
            _userManager = userManager;
            _proposalBusiness = proposalBusiness;
            _questionBusiness = questionBusiness;
            _questionnaireBusiness = questionnaireBusiness;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Entitled, IsCorrect, QuestionId")] Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                //check if QuestionId in proposal is in bdd
                Question question = await _questionBusiness.DetailAsync(proposal.QuestionId);
                if (question == null)
                {
                    return NotFound();
                }

                //check if this user have a permission, if this Questionnaire, Question belongs to him
                User user = await _userManager.GetUserAsync(User);
                Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(question.QuestionnaireId, user.Id);
                if (questionnaire == null)
                {
                    return NotFound();
                }

                await _proposalBusiness.CreateAsync(proposal);

                //this viewbag is for open the collapse when i add some proposal
                ViewBag.Show = "show";
                return PartialView("_AccordionCard", question);
            }
            return NotFound();
        }

        public async Task<bool> Edit(Proposal proposal)
        {
            await _proposalBusiness.EditAsync(proposal);
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            Proposal proposal = await _proposalBusiness.DetailAsync(id);
            if (proposal is null)
            {
                return false;
            }

            await _proposalBusiness.DeleteAsync(proposal);
            return true;
        }
    }
}