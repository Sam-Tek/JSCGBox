using System.Linq;
using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/Questionnaire")]
    [ApiController]
    public class QuestionnaireApiController : ControllerBase
    {
        private readonly IQuestionnaireBusiness _business;

        public QuestionnaireApiController(IQuestionnaireBusiness business)
        {
            _business = business;
        }
        
        [HttpGet]
        public async Task<Questionnaire[]> GetQuestionnairesAsync()
        {
            return (await _business.GetQuestionnairesAsync()).ToArray();
        }
    }
}