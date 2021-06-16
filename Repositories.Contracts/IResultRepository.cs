using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IResultRepository
    {
        public Task<IQueryable<Result>> GetResultsAsync();

        public Task<Result> DetailAsync(int id);

        public Task CreateAsync(Result result);

        public Task EditAsync(Result result);

        public Task DeleteAsync(Result result);
    }
}
