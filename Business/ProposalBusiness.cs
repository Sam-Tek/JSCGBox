using Entities;
using Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ProposalBusiness
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
    }
}
