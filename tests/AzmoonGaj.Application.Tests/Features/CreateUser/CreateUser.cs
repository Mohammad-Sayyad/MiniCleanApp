using AzmoonGaj.Domain.Contract.Interface;
using AzmoonGaj.Domain.DTOs;
using AzmoonGaj.Application.Features.User.Commands.CreateUser;
using AzmoonGaj.Domain.Contract.Interface;
using AzmoonGaj.Domain.DTOs;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AzmoonGaj.Application.Tests.Features.CreateUser
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _handler = new CreateUserCommandHandler(_userServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldCreateUserAndReturnDto()
        {
            var command = new CreateUserCommand
            {
                Name = "Sajjad",
                LastName = "Ghasemi",
                Old = 25,
                Duration = 60,
                ExamDate = DateTime.Now.AddDays(2)
            };

            var expectedResult = new UserDto
            {
                Id = 1,
                Name = command.Name,
                LastName = command.LastName,
                Old = command.Old
            };

            _userServiceMock
                .Setup(s => s.CreateAsync(It.IsAny<CreateUserDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);
            var result = await _handler.Handle(command, CancellationToken.None);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Name.ShouldBe("Sajjad");
            _userServiceMock.Verify(s => s.CreateAsync(command, CancellationToken.None), Times.Once);
        }
    }
}