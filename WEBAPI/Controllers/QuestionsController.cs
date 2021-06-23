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
        public async Task<Question[]> GetQuestionsAsync()
        {
            return (await _business.GetQuestionsAsync()).ToArray();
        }

        [HttpGet("{questionnaireId}")]

        public async Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId)
        {
            return await _business.GetQuestionsByQuestionnaireAsync(questionnaireId);
        }

        [HttpGet("{id}")]
        public async Task<Question> DetailAsync(int id)
        {
            return await _business.DetailAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateAsync(Question result)
        {
             await _business.CreateAsync(result);

            return true;
        }

        [HttpPut]
        public async Task<bool> EditAsync(Question result)
        {
            await _business.EditAsync(result);
            return true;
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(Question result)
        {
            await _business.DeleteAsync(result);
            return true;
        }




        //[HttpGet("{id}")]
        // public async Task<ActionResult<Question>> GetQuestionsByQuestionnaireAsync(int id)
        //{
        //    return await _business.GetQuestionsByQuestionnaireAsync(id);
        // }

    }
}
