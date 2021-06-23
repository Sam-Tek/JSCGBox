using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class QuestionController : Controller
    {
        private UserManager<User> _userManager;
        private IQuestionnaireBusiness _questionnaireBusiness;
        private IQuestionBusiness _questionBusiness;
        private IProposalBusiness _proposalBusiness;
        private IResultBusiness _resultBusiness;

        public QuestionController(UserManager<User> userManager, IQuestionnaireBusiness questionnaireBusiness, IQuestionBusiness questionBusiness, IProposalBusiness proposalBusiness, IResultBusiness resultBusiness)
        {
            _userManager = userManager;
            _questionnaireBusiness = questionnaireBusiness;
            _questionBusiness = questionBusiness;
            _proposalBusiness = proposalBusiness;
            _resultBusiness = resultBusiness;
        }

        public async Task<ActionResult> Participate(int id)
        {
            Questionnaire questionnaire = await _questionnaireBusiness.DetailAsync(id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            Question firstQuestion = questionnaire.Questions.FirstOrDefault(q => q.Order == 1);
            return View(firstQuestion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(Question question)
        {
            User user = await _userManager.GetUserAsync(User);
            //Question question = await _questionBusiness.DetailAsync(id);

            Result result = await GetResult(user, question.Id);

            if (question.Proposals != null)
            {
                foreach (Proposal proposal in question.Proposals)
                {
                    if (proposal.Selected)
                    {
                        // Create ResultProposal
                        await _proposalBusiness.CreateProposalResultAsync(proposal, result);
                        await _resultBusiness.CreateResultProposalAsync(result, proposal);
                    }
                }
            }
            Question nextQuestion = await _questionBusiness.GetNextQuestionAsync(question);
            if (nextQuestion != null)
            {
                return RedirectToAction(nameof(Participate), new { nextQuestion });
            }
            else
            {
                // Redirection vers la page de résultats
                return View();
            }
        }

        public async Task<Result> GetResult(User user, int questionId)
        {
            Result result = await _proposalBusiness.GetResultByUserIdAndQuestionIdAndDateAsync(user.Id, questionId, DateTime.Today);
            if (result == null)
            {
                result = new Result() { ResponseDate = DateTime.Today, User = user, UserId = user.Id };
                await _resultBusiness.CreateAsync(result);
            }
            return result;
        }
    }
}
