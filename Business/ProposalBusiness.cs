using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ProposalBusiness : IProposalBusiness
    {
        private IProposalRepository _proposalRepository;

        public ProposalBusiness(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public async Task<IQueryable<Proposal>> GetProposalsAsync()
        {
            return await _proposalRepository.GetProposalsAsync();
        }

        public async Task<IQueryable<Proposal>> GetProposalsByQuestionAsync(int questionId)
        {
            return await _proposalRepository.GetProposalsByQuestionAsync(questionId);
        }

        public async Task<Proposal> DetailAsync(int id)
        {
            return await _proposalRepository.DetailAsync(id);
        }

        public async Task CreateAsync(Proposal proposal)
        {
            await _proposalRepository.CreateAsync(proposal);
        }

        public async Task EditAsync(Proposal proposal)
        {
            await _proposalRepository.EditAsync(proposal);
        }

        public async Task DeleteAsync(Proposal proposal)
        {
            await _proposalRepository.DeleteAsync(proposal);
        }

        public async Task CreateProposalResultAsync(Proposal proposal, Result result)
        {
            await _proposalRepository.CreateProposalResultAsync(proposal, result);
        }

        public async Task<Result> GetResultByUserIdAndQuestionIdAndDateAsync(string userId, int questionId, DateTime date)
        {
            Result resultReturn = null;
            var proposals = await _proposalRepository.GetProposalsByQuestionAsync(questionId);

            foreach (var proposal in proposals)
            {
                foreach (var result in proposal.Results)
                {
                    if (result.UserId == userId && result.ResponseDate.Date == date.Date)
                    {
                        return result;
                    }
                }
            }
            return resultReturn;
        }
    }
}
