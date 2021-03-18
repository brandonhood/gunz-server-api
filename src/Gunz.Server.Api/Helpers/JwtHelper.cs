using Jose;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Gunz.Server.Api.Models;
using Gunz.Server.Common.Helpers;
using Gunz.Server.Business.Models;

namespace Gunz.Server.Api.Helpers
{
    internal class JwtHelper : IJwtHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly Lazy<TokenSettings> _tokenSettings;

        public JwtHelper(IConfiguration configuration, IDateTimeHelper dateTimeHelper)
        {
            _configuration = configuration;
            _dateTimeHelper = dateTimeHelper;
            _tokenSettings = new Lazy<TokenSettings>(() => _configuration.GetSection("TokenSettings").Get<TokenSettings>());
        }

        public JwtPayload ValidateToken(string payload)
            => JWT.Decode<JwtPayload>(payload, _tokenSettings.Value.SecretSigningKey);

        public string GenerateJwt(int accountId)
        {
            var now = _dateTimeHelper.GetUtcNow();

            var payload = new Dictionary<string, object>()
            {
                ["sub"] = $"{accountId}",
                ["iss"] = "Gunz.Server.Api",
                ["iat"] = _dateTimeHelper.GetSecondsSinceEpoch(now),
                ["exp"] = _dateTimeHelper.GetSecondsSinceEpoch(now.AddHours(6))
            };

            return JWT.Encode(payload, _tokenSettings.Value.SecretSigningKey, JwsAlgorithm.HS256);
        }
    }
}
