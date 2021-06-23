using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProposalRepository
    {
        public Task<IQueryable<Proposal>> GetProposalsAsync();

        public Task<IQueryable<Proposal>> GetProposalsByQuestionAsync(int questionId);

        public Task<Proposal> DetailAsync(int id);

        public Task CreateAsync(Proposal proposal);

        public Task EditAsync(Proposal proposal);

        public Task DeleteAsync(Proposal proposal);

        public Task CreateProposalResultAsync(Proposal proposal, Result result);
    }
}
