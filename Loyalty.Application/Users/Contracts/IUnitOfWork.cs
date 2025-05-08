namespace Loyalty.Application.Users.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
