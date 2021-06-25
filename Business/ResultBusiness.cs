using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ResultBusiness : IResultBusiness
    {
        private IResultRepository _resultRepository;
        private IProposalBusiness _proposalBusiness;

        public ResultBusiness(IResultRepository resultRepository, IProposalBusiness proposalBusiness)
        {
            _resultRepository = resultRepository;
            _proposalBusiness = proposalBusiness;
        }

        public async Task<IQueryable<Result>> GetResultsAsync()
        {
            return await _resultRepository.GetResultsAsync();
        }

        public async Task<Result> DetailAsync(int id)
        {
            return await _resultRepository.DetailAsync(id);
        }

        public async Task CreateAsync(Result result)
        {
            await _resultRepository.CreateAsync(result);
        }

        public async Task EditAsync(Result result)
        {
            await _resultRepository.EditAsync(result);
        }

        public async Task DeleteAsync(Result result)
        {
            await _resultRepository.DeleteAsync(result);
        }

        public async Task CreateResultProposalAsync(Result result, Proposal proposal)
        {
            await _resultRepository.CreateResultProposalAsync(result, proposal);
        }

        public async Task<IQueryable<Result>> GetResultsByUserIdAsync(string userId)
        {
            return await _resultRepository.GetResultsByUserIdAsync(userId);
        }
        public async Task<Result> GetResult(User user, int questionId)
        {
            Result result = await _proposalBusiness.GetResultByUserIdAndQuestionIdAndDateAsync(user.Id, questionId, DateTime.Today);
            if (result == null)
            {
                result = new Result() { ResponseDate = DateTime.Today, User = user, UserId = user.Id };
                await CreateAsync(result);
            }
            return result;
        }
    }
}
