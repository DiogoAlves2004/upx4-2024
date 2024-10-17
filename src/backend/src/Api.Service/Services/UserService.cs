using AutoMapper;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Entities;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Interfaces.Services;
using Infra.UPX4.Domain.Models;

namespace Infra.UPX4.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;


        public UserService(IRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Create(UserDto user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var result = await _userRepository.InsertAsync(_mapper.Map<UserEntity>(userModel));

            return _mapper.Map<UserDto>(result);


        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _userRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var result = await _userRepository.SelectAsync();
            List<UserEntity> resultsArray = new List<UserEntity>();
            foreach (var item in result)
            {
                item.Password = null;
                resultsArray.Add(item);
            }
            return _mapper.Map<IEnumerable<UserDto>>(resultsArray);
        }

        public async Task<UserDto> GetOneById(Guid id)
        {
            var result = await _userRepository.SelectAsync(id);
            result.Password = null;
            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> Update(UserDto user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var result = await _userRepository.UpdateAsync(_mapper.Map<UserEntity>(userModel));
            result.Password = null;
            return _mapper.Map<UserDto>(result);
        }
    }
}