using Loyalty.Application.Users.Commands.CreateUser;
using Loyalty.Application.Users.Commands.UserEarnPoint;
using Loyalty.Application.Users.Queries.GetUserPoints;
using Loyalty.EndPoints.Api.Controllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand dto)
        {
            var result = await _mediator.Send(dto);
            return Ok(result);
        }

        [HttpPost("{id}/earn")]
        public async Task<IActionResult> Earn(long id, [FromBody] UserEarnPointDto dto)
        {
            await _mediator.Send(new UserEarnPointCommand
            {
                Points = dto.Points,
                UserId = id
            });
            return Ok();
        }

        [HttpGet("{id}/points")]
        public async Task<IActionResult> GetPoints(long id)
        {
            var result = await _mediator.Send(new GetUserPointsQuery
            {
                UserId = id
            });
            return Ok(result);
        }
    }
}
