using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<IQueryable<User>> GetUsersAsync();

        public Task<User> DetailAsync(string id);

        public Task CreateAsync(User user);

        public Task EditAsync(User user);

        public Task DeleteAsync(User user);
    }
}
