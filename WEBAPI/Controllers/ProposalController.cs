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
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private IProposalBusiness _business;
 
        public ProposalController(IProposalBusiness business)
        {
            _business = business;
        }



        [HttpGet("{questionId}")]
         public async Task<IQueryable<Proposal>> GetProposalsByQuestionAsync(int questionId)
        {
            return await _business.GetProposalsByQuestionAsync(questionId);
         }
    }
}
