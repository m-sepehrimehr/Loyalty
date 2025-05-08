using Loyalty.Application.Users.Contracts;
using Loyalty.Domain.Common.Exceptions;
using MediatR;

namespace Loyalty.Application.Users.Commands.UserEarnPoint
{
    public class UserEarnPointCommandHandler : IRequestHandler<UserEarnPointCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserEarnPointCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UserEarnPointCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(request.UserId);
            if (user == null)
                throw new BusinessException("User Not Found");

            user.AddPoints(request.Points);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
