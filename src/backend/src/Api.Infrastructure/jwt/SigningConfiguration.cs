
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Infra.UPX4.Infrastructure.jwt
{
    public class SigningConfiguration
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials Credential { get; set; }

        public SigningConfiguration()
        {
            // discart from memory
            using var provider = new RSACryptoServiceProvider(2048);
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            Credential = new SigningCredentials(Key, SecurityAlgorithms.RsaSsaPssSha256Signature);
        }

    }
}