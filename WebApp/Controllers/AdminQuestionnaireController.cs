using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    [Authorize]
    public class AdminQuestionnaireController : Controller
    {
        private UserManager<User> _userManager;
        private IQuestionnaireBusiness _questionnaireBusiness;


        public AdminQuestionnaireController(UserManager<User> userManager, IQuestionnaireBusiness questionnaireBusiness)
        {
            _userManager = userManager;
            _questionnaireBusiness = questionnaireBusiness;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            return View(user.Questionnaires);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,DefaultTimer")] Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                questionnaire.User = await _userManager.GetUserAsync(User);
                await _questionnaireBusiness.CreateAsync(questionnaire);
                return RedirectToAction(nameof(Index));
            }
            return View(questionnaire);
        }

        public async Task<IActionResult> Edit(int id = 0)
        {
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(id, user.Id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Title,DefaultTimer")] Questionnaire questionnaire)
        {
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaireBDD = await _questionnaireBusiness.DetailByUserIdAsync(questionnaire.Id, user.Id);

            if (questionnaireBDD == null)
            {
                return NotFound();
            }

            questionnaireBDD.Title = questionnaire.Title;
            questionnaireBDD.DefaultTimer = questionnaire.DefaultTimer;

            await _questionnaireBusiness.EditAsync(questionnaireBDD);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id = 0)
        {
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(id, user.Id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // GET: Questionnaires/Delete/5
        public async Task<IActionResult> Delete(int id = 0)
        {
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(id, user.Id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // POST: Questionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id = 0)
        {
            User user = await _userManager.GetUserAsync(User);
            Questionnaire questionnaire = await _questionnaireBusiness.DetailByUserIdAsync(id, user.Id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            await _questionnaireBusiness.DeleteAsync(questionnaire);
            return RedirectToAction(nameof(Index));
        }
    }
}