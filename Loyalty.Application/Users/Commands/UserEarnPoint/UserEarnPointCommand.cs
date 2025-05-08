using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.Users.Commands.UserEarnPoint
{
    public class UserEarnPointCommand : IRequest<Unit>
    {
        public long UserId { get; set; }
        public int Points { get; set; }
    }
}
