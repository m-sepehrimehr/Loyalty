using Loyalty.Application.Users.Contracts;
using Loyalty.Domain.Users;

namespace Loaylty.Infrastructure.Entities.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly LoayltyContext _loayltyContext;

        public UserRepository(LoayltyContext loayltyContext)
        {
            _loayltyContext = loayltyContext;
        }

        public User Add(User user)
        {
            return _loayltyContext.Add(user).Entity;
        }

        public async Task<User?> GetAsync(long id)
        {
            return await _loayltyContext.Set<User>().FindAsync(id);
        }

        public User Update(User user)
        {
            return _loayltyContext.Update(user).Entity;
        }
    }
}
