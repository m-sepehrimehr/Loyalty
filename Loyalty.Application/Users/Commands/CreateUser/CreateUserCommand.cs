using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Name { get; set; }
    }
    public class CreateUserResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
