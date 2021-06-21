using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Repositories.Contracts;

namespace Repositories.Api
{
    public class QuestionRepository : IQuestionRepository
    {
        private HttpClient _httpClient;

        public QuestionRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("localhost:5002"),
                Timeout = TimeSpan.FromSeconds(30)
            };
            
            _httpClient.DefaultRequestHeaders.Accept.Clear();  
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IQueryable<Question>> GetQuestionsAsync()
        {
            var response = await _httpClient.GetAsync("Question/Get");
            return JsonSerializer.Deserialize<IQueryable<Question>>(response.Content.ToString() ?? string.Empty);
        }

        public async Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId)
        {
            var response = await _httpClient.GetAsync($"Question/Get/{questionnaireId}");
            return JsonSerializer.Deserialize<IQueryable<Question>>(response.Content.ToString() ?? string.Empty);
        }

        public Task<Question> DetailAsync(int id)
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
    }
}