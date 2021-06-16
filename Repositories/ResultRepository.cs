using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ResultRepository : IResultRepository
    {
        private JSCGContext _context;

        public ResultRepository(JSCGContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Result>> GetResultsAsync()
        {
            var results = await _context.Results.ToListAsync();
            return results.AsQueryable();
        }

        public async Task<Result> DetailAsync(int id)
        {
            return await _context.Results.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task CreateAsync(Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Result result)
        {
            _context.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Result result)
        {
            _context.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
