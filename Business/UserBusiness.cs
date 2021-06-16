using Entities;
using Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private IUserRepository _userRepository;
        
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IQueryable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> DetailAsync(int id)
        {
            return await _userRepository.DetailAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task EditAsync(User user)
        {
            await _userRepository.EditAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await _userRepository.DeleteAsync(user);
        }
    }
}
