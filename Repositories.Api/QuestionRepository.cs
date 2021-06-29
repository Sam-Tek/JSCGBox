using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Repositories.Contracts;
using Microsoft.Extensions.Configuration;

namespace Repositories.Api
{
    public class QuestionRepository : IQuestionRepository
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public QuestionRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            _httpClient = new HttpClient{
                BaseAddress = new Uri(_configuration["ApiUrl"]),
                Timeout = TimeSpan.FromSeconds(30)
            };
            
            _httpClient.DefaultRequestHeaders.Accept.Clear();  
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<IQueryable<Question>> GetQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId)
        {
            var response = await _httpClient.GetStreamAsync($"Question/Get/{questionnaireId}");
            var question = JsonSerializer.Deserialize<Question[]>(response.ToString() ?? string.Empty);

            return new EnumerableQuery<Question>(question ?? Array.Empty<Question>());
        }

        public Task<Question> DetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Question result)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Question result)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Question result)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetNextQuestionAsync(Question questionInProgress)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetFirstQuestionAsync(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Question>> GetQuestionsByQuestionnaireOrderAsync(int questionnaireId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderExistAsync(Questionnaire questionnaire, int order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderExistExcludeQuestionAsync(Questionnaire questionnaire, Question question)
        {
            throw new NotImplementedException();
        }
    }
}