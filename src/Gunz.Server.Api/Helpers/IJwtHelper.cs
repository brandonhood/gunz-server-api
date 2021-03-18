using Gunz.Server.Business.Models;

namespace Gunz.Server.Api.Helpers
{
    public interface IJwtHelper
    {
        JwtPayload ValidateToken(string payload);

        string GenerateJwt(int accountId);
    }
}
