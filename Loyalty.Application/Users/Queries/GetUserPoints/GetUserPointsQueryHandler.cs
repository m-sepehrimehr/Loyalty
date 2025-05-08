using Loyalty.Application.Users.Contracts;
using Loyalty.Domain.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Loyalty.Application.Users.Queries.GetUserPoints
{
    public class GetUserPointsQueryHandler : IRequestHandler<GetUserPointsQuery, GetUserPointsResponse>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IUnitOfWork _unitOfWork;
        private const int _expireInMinutes = 10;
        public GetUserPointsQueryHandler(IDistributedCache distributedCache, IUnitOfWork unitOfWork)
        {
            _distributedCache = distributedCache;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUserPointsResponse> Handle(GetUserPointsQuery request, CancellationToken cancellationToken)
        {
            var key = $"user-points-{request.UserId}";
            var result = await _distributedCache.GetStringAsync(key);
            if (result != null) return new GetUserPointsResponse
            {
                UserId = request.UserId,
                Points = int.Parse(result)
            };

            var user = await _unitOfWork.UserRepository.GetAsync(request.UserId);
            if (user == null)
                throw new BusinessException("User Not Found");

            var points = user.Points.Sum(p => (int?)p.Amount) ?? 0;
            await _distributedCache.SetStringAsync(
                key,
                points.ToString(),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_expireInMinutes)
                });

            return new GetUserPointsResponse
            {
                UserId = user.Id,
                Points = points
            };
        }
    }
}
