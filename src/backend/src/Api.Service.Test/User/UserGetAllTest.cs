using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Moq;


namespace Api.Service.Test.User;


public class UserGetAllTest : UserMock
{

    private IUserService _userService;
    private Mock<IUserService> _userServiceMock;


    [Fact(DisplayName = "Should be able get all users")]
    public async Task Should_Be_Able_Get_All_Users(){

        _userServiceMock = new Mock<IUserService>();
        _userServiceMock.Setup(x => x.GetAll()).ReturnsAsync(userList);

        _userService = _userServiceMock.Object;

        var result = await _userService.GetAll();

        Assert.NotNull(result);
        Assert.Equal(result.Count(),10 );

    }


    [Fact(DisplayName = "Should_Return_A_Empty_List_When_Not_Exist_Users")]
    public async Task Should_Return_A_Empty_List_When_Not_Exist_Users(){
        
        _userServiceMock = new Mock<IUserService>();

        var emptyListUsers = new List<UserDto>();

        _userServiceMock.Setup(x => x.GetAll()).ReturnsAsync(emptyListUsers.AsEnumerable());

        _userService = _userServiceMock.Object;


        var resultNull = await _userService.GetAll();

         Assert.Equal(resultNull.Count(),0);
    }
    
}