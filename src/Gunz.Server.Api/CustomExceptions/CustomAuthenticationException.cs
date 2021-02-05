using System;

namespace Gunz.Server.Api.CustomExceptions
{
    public class CustomAuthenticationException : Exception
    {
        public CustomAuthenticationException(string message)
            : base(message)
        { }
    }
}
