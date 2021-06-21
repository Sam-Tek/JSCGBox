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
        private IQuestionnaireBusiness _buisness;
        

        public AdminQuestionnaireController(UserManager<User> userManager, IQuestionnaireBusiness buisness)
        {
            _userManager = userManager;
            _buisness = buisness;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            return View(user.Questionnaires);
        }

        public IActionResult Create()
        {
            Questionnaire questionnaire = new();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Questionnaire questionnaire)
        {
            await _buisness.CreateAsync(questionnaire);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Questionnaire questionnaire = await _buisness.DetailAsync(id);
            return View(questionnaire);
        }
        
        [HttpPost]

        public async Task<IActionResult> Edit(Questionnaire questionnaire)
        {
            await _buisness.EditAsync(questionnaire);
            return RedirectToAction("Edit", "AdminQuestionnaire", questionnaire.Id);
        }
    }
}