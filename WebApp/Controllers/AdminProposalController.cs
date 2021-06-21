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
        private IProposalBusiness _business;
        private UserManager<User> _userManager;
        public AdminProposalController(UserManager<User> userManager, IProposalBusiness business)
        {
            _userManager = userManager;
            _business = business;
        }
        public async Task<bool> Add(Proposal proposal)
        {
            await _business.CreateAsync(proposal);
            return true;
        }

        public async Task<bool> Edit(Proposal proposal)
        {
            await _business.EditAsync(proposal);
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            Proposal proposal = await _business.DetailAsync(id);
            if (proposal is null)
            {
                return false;
            }

            await _business.DeleteAsync(proposal);
            return true;
        }
    }
}