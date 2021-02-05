using System;

namespace Gunz.Server.LobbyApi.CustomExceptions
{
    public class CustomAccountAccessException : Exception
    {
        public CustomAccountAccessException(int requestingAccountId, int targetAccountId)
        {
            RequestingAccountId = requestingAccountId;
            TargetAccountId = targetAccountId;
        }

        public int RequestingAccountId { get; }

        public int TargetAccountId { get; }
    }
}
