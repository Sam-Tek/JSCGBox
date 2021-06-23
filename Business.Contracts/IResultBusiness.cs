using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IResultBusiness
    {
        public Task<IQueryable<Result>> GetResultsAsync();

        public Task<Result> DetailAsync(int id);

        public Task CreateAsync(Result result);

        public Task EditAsync(Result result);

        public Task DeleteAsync(Result result);

        public Task CreateResultProposalAsync(Result result, Proposal proposal);

        public Task<IQueryable<Result>> GetResultsByUserIdAsync(string userId);
    }
}
