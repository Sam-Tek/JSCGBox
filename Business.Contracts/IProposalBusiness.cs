using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IProposalBusiness
    {
        public Task<IQueryable<Proposal>> GetProposalsAsync();

        public Task<IQueryable<Proposal>> GetProposalsByQuestionAsync(int questionId);

        public Task<Proposal> DetailAsync(int id);

        public Task CreateAsync(Proposal proposal);

        public Task EditAsync(Proposal proposal);

        public Task DeleteAsync(Proposal proposal);

        public Task CreateProposalResultAsync(Proposal proposal, Result result);

        public Task<Result> GetResultByUserIdAndQuestionIdAndDateAsync(string userId, int questionId, DateTime date);
    }
}
