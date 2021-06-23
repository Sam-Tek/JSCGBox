using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class QuestionnaireController : Controller
    {
        private UserManager<User> _userManager;
        private IQuestionnaireBusiness _questionnaireBusiness;

        public QuestionnaireController(UserManager<User> userManager, IQuestionnaireBusiness questionnaireBusiness)
        {
            _userManager = userManager;
            _questionnaireBusiness = questionnaireBusiness;
        }

        // GET
        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            var results = user.Results;
            var questionnaires = new List<Questionnaire>();
            foreach (var result in results)
            {
                // Comme toutes les propositions liées à un résultat ne proviennent que d'un seul questionnaire,
                // on peut récupérer la première proposition pour remonter au questionnaire
                if (result.Proposals != null && result.Proposals.Count > 0)
                {
                    Proposal firstProposal = result.Proposals.FirstOrDefault();
                    Question firstQuestion = firstProposal.Question;
                    Questionnaire questionnaire = firstQuestion.Questionnaire;
                    questionnaires.Add(questionnaire);
                }
            }

            return View(questionnaires);
        }

        public async Task<IActionResult> Search()
        {
            var questionnaires = await _questionnaireBusiness.GetQuestionnairesAsync();
            return View(questionnaires);
        }
    }
}