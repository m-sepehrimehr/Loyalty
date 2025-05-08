using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.Users.Commands.UserEarnPoint
{
    public class UserEarnPointCommandValidator : AbstractValidator<UserEarnPointCommand>
    {
        public UserEarnPointCommandValidator()
        {
            RuleFor(x=>x.Points).GreaterThan(0);
        }
    }
}
