using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        private JSCGContext _context;

        public UserRepository(JSCGContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.AsQueryable();
        }

        public async Task<User> DetailsAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
