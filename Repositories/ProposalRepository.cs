using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProposalRepository
    {
        private JSCGContext _context;

        public ProposalRepository(JSCGContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Proposal>> GetProposalAsync()
        {
            var proposals = await _context.Proposals.ToListAsync();
            return proposals.AsQueryable();
        }

        public async Task<Proposal> DetailsAsync(int id)
        {
            return await _context.Proposals.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task CreateAsync(Proposal proposal)
        {
            _context.Proposals.Add(proposal);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Proposal proposal)
        {
            _context.Update(proposal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Proposal proposal)
        {
            _context.Remove(proposal);
            await _context.SaveChangesAsync();
        }
    }
}
