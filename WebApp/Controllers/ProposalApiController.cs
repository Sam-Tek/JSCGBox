using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Controllers
{
    [Route("api/Proposal")]
    [ApiController]
    public class ProposalApiController : ControllerBase
    {
        private IProposalBusiness _business;

        public ProposalApiController(IProposalBusiness business)
        {
            _business = business;
        }


        [HttpGet("ByQuestion/{questionId}")]
        public async Task<Proposal[]> GetProposalsByQuestionAsync(int questionId)
        {
            return (await _business.GetProposalsByQuestionAsync(questionId)).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<Proposal> DetailAsync(int id)
        {
            return await _business.DetailAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateAsync(Proposal proposal)
        {
            await _business.CreateAsync(proposal);
            return true;
        }

        [HttpPut]
        public async Task<bool> EditAsync(Proposal proposal)
        {
            await _business.EditAsync(proposal);

            return true;
        }

        [HttpDelete("{proposal}")]
        public async Task<bool> DeleteAsync(Proposal proposal)
        {
            await _business.DeleteAsync(proposal);

            return true;
        }
    }
}