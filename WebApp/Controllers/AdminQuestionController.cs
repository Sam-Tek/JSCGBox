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
        private IQuestionBusiness _business;
        private UserManager<User> _userManager;

        public AdminQuestionController(UserManager<User> userManager, IQuestionBusiness business)
        {
            _userManager = userManager;
            _business = business;
        }

        [HttpPost]
        public async Task<bool> Add(Question question)
        {
            await _business.CreateAsync(question);
            return true;
        }

        [HttpPost]
        public async Task<bool> Edit(Question question)
        {
            await _business.EditAsync(question);
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            Question question = await _business.DetailAsync(id);
            if (question is null)
            {
                return false;
            }
            await _business.DeleteAsync(question);
            return true;
        }
    }
}