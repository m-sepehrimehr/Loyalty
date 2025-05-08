using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.Users.Queries.GetUserPoints
{
    public class GetUserPointsQuery : IRequest<GetUserPointsResponse>
    {
        public long UserId { get; set; }
    }
    public class GetUserPointsResponse
    {
        public long UserId { get; set; }
        public int Points { get; set; }
    }
}
