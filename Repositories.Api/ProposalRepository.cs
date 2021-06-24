using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Repositories.Contracts;

namespace Repositories.Api
{
    public class ProposalRepository : IProposalRepository
    {
        private HttpClient _httpClient;

        

        public ProposalRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5002/"),
                Timeout = TimeSpan.FromSeconds(30)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IQueryable<Proposal>> GetProposalsAsync()
        {
            var response = await _httpClient.GetStreamAsync("/api/Proposals");
            return await JsonSerializer.DeserializeAsync<IQueryable<Proposal>>(response);
        }

        public async Task<IQueryable<Proposal>> GetProposalsByQuestionAsync(int questionId)
        {
            var response = await _httpClient.GetAsync($"Proposal/Get/{questionId}");
            return JsonSerializer.Deserialize<IQueryable<Proposal>>(response.Content.ToString() ?? string.Empty);
        }

        public Task<Proposal> DetailAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(Proposal result)
        {
            throw new System.NotImplementedException();
        }

        public Task EditAsync(Proposal result)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Proposal result)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateProposalResultAsync(Proposal proposal, Result result)
        {
            throw new NotImplementedException();
        }
    }
}