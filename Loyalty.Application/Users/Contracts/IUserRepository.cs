using Loyalty.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.Users.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetAsync(long id);
        User Add(User user);
        User Update(User user);
    }
}
