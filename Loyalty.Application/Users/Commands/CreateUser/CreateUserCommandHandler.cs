using Loyalty.Application.Users.Contracts;
using Loyalty.Domain.Users;
using MediatR;

namespace Loyalty.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name);
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return new CreateUserResponse
            {
                Id = user.Id,
                Name = user.Name,
            };
        }
    }
}
