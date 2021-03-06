using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Microsoft.Extensions.Configuration;

namespace Repositories.Api
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        // GET
        public QuestionnaireRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            _httpClient = new HttpClient{
                BaseAddress = new Uri(_configuration["ApiUrl"]),
                Timeout = TimeSpan.FromSeconds(30)
            };
            
            _httpClient.DefaultRequestHeaders.Accept.Clear();  
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));        }

        public async Task<IQueryable<Questionnaire>> GetQuestionnairesAsync()
        {
            var response = _httpClient.GetStreamAsync("/api/Questionnaire");
            var questionnaires = await JsonSerializer.DeserializeAsync<Questionnaire[]>(await response) ?? Array.Empty<Questionnaire>();

            return new EnumerableQuery<Questionnaire>(questionnaires);
        }

        public Task<Questionnaire> DetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Questionnaire> DetailByUserIdAsync(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Questionnaire result)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Questionnaire result)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Questionnaire result)
        {
            throw new NotImplementedException();
        }
    }
}