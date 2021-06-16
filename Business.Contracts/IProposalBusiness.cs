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

        public Task<Proposal> DetailAsync(int id);

        public Task CreateAsync(Proposal proposal);

        public Task EditAsync(Proposal proposal);

        public Task DeleteAsync(Proposal proposal);
    }
}
