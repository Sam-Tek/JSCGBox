using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class QuestionnaireController : Controller
    {
        private UserManager<User> _userManager;
        private IQuestionnaireBusiness _business;

        public QuestionnaireController(UserManager<User> userManager, IQuestionnaireBusiness business)
        {
            _userManager = userManager;
            _business = business;
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
                Proposal firstProposal = result.Proposals.FirstOrDefault();
                Question firstQuestion = firstProposal.Question;
                Questionnaire questionnaire = firstQuestion.Questionnaire;
                questionnaires.Add(questionnaire);
            }

            return View(questionnaires);
        }

        public async Task<IActionResult> Search()
        {
            var questionnaires = await _business.GetQuestionnairesAsync();
            return View(questionnaires);
        }

        public async Task<IActionResult> Participate(int id)
        {
            Questionnaire questionnaire = await _business.DetailAsync(id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }
    }
}