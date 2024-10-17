using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Moq;


namespace Api.Service.Test.User;


public class UserCreateTest : UserMock
{

    private IUserService _userService;
    private Mock<IUserService> _userServiceMock;


    [Fact(DisplayName = "Should_Be_Able_Create_a_User")]
    public async Task Should_Be_Able_Create_a_User(){

        _userServiceMock = new Mock<IUserService>();
        _userServiceMock.Setup(x => x.Create(UserDto)).ReturnsAsync(UserDto);

        _userService = _userServiceMock.Object;

        var result = await _userService.Create(UserDto);

        Assert.NotNull(result);
        Assert.True(result.Id == Id);
        Assert.Equal(Name , result.Name);

    }
    
}