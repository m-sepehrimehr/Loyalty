using Loyalty.Application.Users.Commands.UserEarnPoint;
using Loyalty.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Loyalty.Test
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task EarnPoints_ReturnsOk()
        {
            var mockService = new Mock<IMediator>();
            mockService.Setup(x => x.Send(new UserEarnPointCommand
            {
                Points = 10,
                UserId = 1
            },default)).ReturnsAsync(Unit.Value);

            var controller = new UsersController(mockService.Object);
            var result = await controller.Earn(1, new EndPoints.Api.Controllers.Dtos.UserEarnPointDto(10));

            Assert.IsType<OkResult>(result);
        }
    }
}