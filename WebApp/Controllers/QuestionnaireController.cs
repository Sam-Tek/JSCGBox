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
        private IResultBusiness _resultBusiness;

        public QuestionnaireController(UserManager<User> userManager, IQuestionnaireBusiness questionnaireBusiness, IResultBusiness resultBusiness)
        {
            _userManager = userManager;
            _questionnaireBusiness = questionnaireBusiness;
            _resultBusiness = resultBusiness;
        }

        // GET
        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            var results = user.Results;

            return View(results);
        }

        public async Task<IActionResult> Search()
        {
            var questionnaires = await _questionnaireBusiness.GetQuestionnairesAsync();
            return View(questionnaires);
        }

        // GET: Results/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Result result = await _resultBusiness.DetailAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _resultBusiness.DeleteAsync(result);

            return RedirectToAction(nameof(Index));
        }
    }
}