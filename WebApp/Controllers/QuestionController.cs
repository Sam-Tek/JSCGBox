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

        public async Task<ActionResult> Participate(int id, int order)
        {
            Questionnaire questionnaire = await _questionnaireBusiness.DetailAsync(id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            Question question = questionnaire.Questions.FirstOrDefault(q => q.Order == order);

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(List<int> proposals, int Id)
        {
            User user = await _userManager.GetUserAsync(User);
            Question question = await _questionBusiness.DetailAsync(Id);

            Result result = await _resultBusiness.GetResult(user, question.Id);

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
                return RedirectToAction(nameof(Participate), new { id = nextQuestion.QuestionnaireId, order = nextQuestion.Order });
            }
            else
            {
                //Redirection vers la page de résultats
                return RedirectToAction("", "Result", new { id = result.Id });
            }
        }

        ////public void ManageTimer(Questionnaire questionnaire, Question question)
        ////{
        ////    duration = question.Timer ?? questionnaire.DefaultTimer;

        ////    Timer timer = new Timer();
        ////    timer.Interval = 1000; //1 sec
        ////    timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        ////    timer.Enabled = true;
        ////    timer.Start();
        ////}

        ////private void OnTimedEvent(object source, ElapsedEventArgs e)
        ////{
        ////    if (duration == 0)
        ////    {
        ////        ((Timer)source).Stop();
        ////        // Redirection vers la question suivante
        ////        return RedirectToAction(nameof(Participate), new { id = nextQuestion.QuestionnaireId, order = nextQuestion.Order });
        ////    }
        ////    else if (duration > 0)
        ////    {
        ////        duration--;
        ////        ViewBag.Countdown = duration.ToString();
        ////    }
        ////}
    }
}
