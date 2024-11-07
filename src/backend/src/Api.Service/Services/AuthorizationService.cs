
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Infra.UPX4.Domain.Mappers;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Infra.UPX4.Infrastructure.jwt;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Security;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Interfaces.Services;

namespace Infra.UPX4.Service.Services
{
    public class AuthorizationService : IAuthorizationService
    {

        private IUserRepository _userRepository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        public IConfiguration _configuration { get; }

        public AuthorizationService(
            IUserRepository userRepository,
            SigningConfiguration signingConfiguration,
            TokenConfiguration tokenConfiguration,
            IConfiguration configuration
            )
        {
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }
        public async Task<object> Login(LoginDto loginDto)
        {

            if (loginDto != null && !string.IsNullOrWhiteSpace(loginDto.Email))
            {
                var baseUser = await _userRepository.GetByEmail(loginDto.Email);

                if (baseUser != null && baseUser.Password == loginDto.Password)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]{
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName,baseUser.Email)
                        });

                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreteToken(identity, createDate, expirationDate, handler);
                    return new TokenMapper().SuccessResponse(createDate, expirationDate, token, loginDto);
                }
            }

            return new TokenMapper().FailedResponse();
        }

        private string CreteToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.Credential,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);

            return token;
        }


    }
}