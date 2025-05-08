using Loyalty.Application.Users.Contracts;

namespace Loaylty.Infrastructure.Persistence.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        private readonly LoayltyContext _loayltyContext;
        public UnitOfWork(IUserRepository userRepository, LoayltyContext loayltyContext)
        {
            UserRepository = userRepository;
            _loayltyContext = loayltyContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _loayltyContext.SaveChangesAsync();    
        }
    }
}
