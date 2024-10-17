using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Users.Test
{
    public class UsersDataTest : BaseTest , IClassFixture<DbTest>
    {
        
        private ServiceProvider _serviceProvider;

        public UsersDataTest(DbTest dbtest){
            _serviceProvider = dbtest.ServiceProvider;
        }

        [Fact(DisplayName = "Users")]
        [Trait("CRUD","UserEntity")]
        public async  Task User_Repository_Test(){

            using (var context = _serviceProvider.GetService<MyContext>()){

                UserRepository _repository  = new UserRepository(context);
                UserEntity _entity = new UserEntity{Name = Faker.Name.FullName(),Email = Faker.Internet.Email(), Password = Faker.Name.Last()};

                // InsertAsync
                var result = await _repository.InsertAsync(_entity);
                
                Assert.NotNull(result);
                Assert.NotNull(result.CreateAt);
                Assert.Equal( _entity.Name, result.Name);
                Assert.Equal(_entity.Email, result.Email);
                Assert.Equal(_entity.Password, result.Password);
                Assert.False(result.Id == Guid.Empty);
                Assert.True(result.UpdatedAt == null);


                // UpdateAsync
                var resultUpdate = await _repository.UpdateAsync(_entity);
                
                _entity.Name = Faker.Name.FullName();
                Assert.NotNull(result);
                Assert.NotNull(resultUpdate.UpdatedAt);
                Assert.Equal( _entity.Name, resultUpdate.Name);
                Assert.Equal(_entity.Email, resultUpdate.Email);
                Assert.Equal(_entity.Password, resultUpdate.Password);
                Assert.False(resultUpdate.Id == Guid.Empty);


                // SelectAsync
                var resultGet = await _repository.SelectAsync(_entity.Id);

                Assert.NotNull(resultGet);
                Assert.NotNull(resultUpdate.UpdatedAt);
                Assert.NotNull(result.CreateAt);
                Assert.Equal( _entity.Name, resultGet.Name);
                Assert.Equal(_entity.Email, resultGet.Email);
                Assert.Equal(_entity.Password, resultGet.Password);
                Assert.False(resultGet.Id == Guid.Empty);


                // SelectAsync Enumerable
                var resultGetAll = await _repository.SelectAsync();

                Assert.NotNull(resultGetAll);
                Assert.True(resultGetAll.Count() > 0 );

                // DeleteAsync
                var resultDelete = await _repository.DeleteAsync(_entity.Id);
                Assert.True(resultDelete);


                // GetByEmail & Find Admin 
                var resultGetByEmail = await _repository.GetByEmail("adm@mail.com");
                Assert.Equal( "Adm", resultGetByEmail.Name);
                Assert.Equal("adm@mail.com",resultGetByEmail.Email);
                Assert.Equal("adm123", resultGetByEmail.Password);

            }
        }
    }
}