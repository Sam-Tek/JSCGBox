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
    public class QuestionsController : ControllerBase
    {
        private IQuestionBusiness _business;
       

        public QuestionsController(IQuestionBusiness business)
        {
    
            _business = business;
        }

        [HttpGet]
        public async Task<IQueryable<Question>> GetQuestionsAsync()
        {
            return await _business.GetQuestionsAsync();
        }


        //[HttpGet("{id}")]
       // public async Task<ActionResult<Question>> GetQuestionsByQuestionnaireAsync(int id)
        //{
        //    return await _business.GetQuestionsByQuestionnaireAsync(id);
       // }

    }
}
