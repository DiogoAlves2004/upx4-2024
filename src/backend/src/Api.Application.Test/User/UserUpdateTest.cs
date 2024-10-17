using System.Net;
using Api.Aplication.Controllers;
using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.User;

public class UserUpdateTest
{
    [Fact(DisplayName = "Should_Be_Able_Update_A_User")]
    public async void Should_Be_Able_Update_A_User()
    {

        var userMock = new UserMock();
        var serviceMock = new Mock<IUserService>();

        serviceMock.Setup(x => x.Update(UserMock.UserDto)).ReturnsAsync(UserMock.UserDto);

        var _controller = new UsersController(serviceMock.Object);

        Mock<IUrlHelper> url = new Mock<IUrlHelper>();
        url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://test.com");

        _controller.Url = url.Object;

        var result = await _controller.Update(UserMock.UserDto);
        var value = ((OkObjectResult)result).Value as UserDto;

        Assert.True(result is OkObjectResult);
        Assert.NotNull(result);
        Assert.True(UserMock.UserDto.Id == value.Id);
        Assert.Equal(UserMock.UserDto.Name, value.Name);
        Assert.Equal(UserMock.UserDto.Email, value.Email);

    }

    [Fact(DisplayName = "Should_Return_InternalServerError_When_UserService_Throws")]
    public async void Should_Return_InternalServerError_When_UserService_Throws()
    {

        var userMock = new UserMock();
        var serviceMock = new Mock<IUserService>();

        serviceMock.Setup(x => x.Update(UserMock.UserDto)).ThrowsAsync(new ArgumentException("Simulated exception"));

        var _controller = new UsersController(serviceMock.Object);

        Mock<IUrlHelper> url = new Mock<IUrlHelper>();
        url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://test.com");

        _controller.Url = url.Object;


        var result = await _controller.Update(UserMock.UserDto);

        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
        Assert.Equal("Simulated exception", (string)statusCodeResult.Value);
    }

    [Fact(DisplayName = "Should_Return_BadRequest_When_Model_Throws")]
    public async void Should_Return_BadRequest_When_Model_Throws()
    {

        var userMock = new UserMock();
        var serviceMock = new Mock<IUserService>();

        serviceMock.Setup(x => x.Update(UserMock.UserDto)).ReturnsAsync(UserMock.UserDto);

        var _controller = new UsersController(serviceMock.Object);
        _controller.ModelState.AddModelError("Field", "Field is required");

        Mock<IUrlHelper> url = new Mock<IUrlHelper>();
        url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://test.com");

        _controller.Url = url.Object;


        var result = await _controller.Update(UserMock.UserDto);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var errorResponse = (SerializableError)badRequestResult.Value;

        Assert.True(result is BadRequestObjectResult);
        Assert.Equal(400, badRequestResult.StatusCode);
        Assert.IsType<SerializableError>(badRequestResult.Value);
        Assert.True(errorResponse.ContainsKey("Field"));
        Assert.Equal(new string[] { "Field is required" }, (string[])errorResponse["Field"]);

    }
}

