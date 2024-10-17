using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit.Sdk;

namespace Api.Service.Test.User;


public class UserGetOneById : UserMock
{

    private IUserService _userService;
    private Mock<IUserService> _userServiceMock;


    [Fact(DisplayName = "Should be able get one user by id")]
    public async Task Should_Be_Able_Get_User_By_Id(){

        _userServiceMock = new Mock<IUserService>();
        _userServiceMock.Setup(x => x.GetOneById(Id)).ReturnsAsync(UserDto);

        // depencie inject mock
        _userService = _userServiceMock.Object;

        var result = await _userService.GetOneById(Id);

        Assert.NotNull(result);
        Assert.True(result.Id == Id);
        Assert.Equal(Name , result.Name);
        
    }


    [Fact(DisplayName = "Should_Return_Null_When_Id_not_match")]
    public async Task Should_Return_Null_When_Id_not_match(){
        
        _userServiceMock = new Mock<IUserService>();
        _userServiceMock.Setup(x => x.GetOneById(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
        _userService = _userServiceMock.Object;


        var resultNull = await _userService.GetOneById(Id);

        Assert.Null(resultNull);
    }
    
}