using System;

namespace Gunz.Server.Common.CustomExceptions
{
    public class CustomAuthenticationException : Exception
    {
        public CustomAuthenticationException(string message)
            : base(message)
        { }
    }
}
