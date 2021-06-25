using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace WebApp.Controllers
{
    public class QuestionController : Controller
    {
        private UserManager<User> _userManager;
        private IQuestionnaireBusiness _questionnaireBusiness;
        private IQuestionBusiness _questionBusiness;
        private IProposalBusiness _proposalBusiness;
        private IResultBusiness _resultBusiness;

        //private int duration;

        public QuestionController(UserManager<User> userManager, IQuestionnaireBusiness questionnaireBusiness, IQuestionBusiness questionBusiness, IProposalBusiness proposalBusiness, IResultBusiness resultBusiness)
        {
            _userManager = userManager;
            _questionnaireBusiness = questionnaireBusiness;
            _questionBusiness = questionBusiness;
            _proposalBusiness = proposalBusiness;
            _resultBusiness = resultBusiness;
        }

        public async Task<ActionResult> Participate(int questionnaireId, int order, bool isFirstQuestion)
        {
            Questionnaire questionnaire = await _questionnaireBusiness.DetailAsync(questionnaireId);

            if (questionnaire == null)
            {
                return NotFound();
            }
            Question question;
            if (isFirstQuestion)
            {
                question = await _questionBusiness.GetFirstQuestionAsync(questionnaire);
            }
            else
            {
                question = questionnaire.Questions.FirstOrDefault(q => q.Order == order);
            }

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(List<int> proposals, int Id)
        {
            User user = await _userManager.GetUserAsync(User);
            Question question = await _questionBusiness.DetailAsync(Id);

            Result result = await _resultBusiness.GetResult(user, question.QuestionnaireId);

            if (proposals.Count > 0)
            {
                foreach (Proposal proposal in question.Proposals.Where(p => proposals.Contains(p.Id)).ToList())
                {
                    // Create ResultProposal
                    await _proposalBusiness.CreateProposalResultAsync(proposal, result);
                }
            }
            Question nextQuestion = await _questionBusiness.GetNextQuestionAsync(question);
            if (nextQuestion != null)
            {
                // Redirection vers la question suivante
                return RedirectToAction(nameof(Participate), new { questionnaireId = nextQuestion.QuestionnaireId, order = nextQuestion.Order, isFirstQuestion = false });
            }
            else
            {
                //Redirection vers la page de résultats
                return RedirectToAction("Index", "Result", new { id = result.Id });
            }
        }
    }
}
