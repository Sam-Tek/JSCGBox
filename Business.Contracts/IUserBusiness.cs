using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IUserBusiness
    {
        public Task<IQueryable<User>> GetUsersAsync();

        public Task<User> DetailAsync(string id);

        public Task CreateAsync(User user);

        public Task EditAsync(User user);

        public Task DeleteAsync(User user);
    }
}
