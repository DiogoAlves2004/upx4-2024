using Api.Domain.Dto;

namespace Api.Application.Test.User;

public class UserMock
{

    public UserMock()
    {
        Id = Guid.NewGuid();
        Name = Faker.Name.FullName();
        Email = Faker.Internet.Email();
        Password = Faker.Internet.UserName();
        
        for (int i = 0; i < 10; i++)
        {
            var dto = new UserDto(){
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Password = Faker.Internet.UserName(),
            };
            userList.Add(dto);
        }

        UserDto = new UserDto(){
            Id = Id,
            Name = Name,
            Email = Email,
            Password = Password,
        };
    }
    public static Guid Id { get; set; }
    public static string Name{get;set;}

    public static string Email { get; set; }

    public static string Password{get;set;}

    public static List<UserDto> userList = new List<UserDto>();

    public static UserDto UserDto;

}