using Gunz.Server.Domain.Enums.Accounts;
using System;

namespace Gunz.Server.Business.Models
{
    public class RequestingAccountInfo
    {
        public RequestingAccountInfo(JwtPayload jwtPayload)
        {
            AccountId = Convert.ToInt32(jwtPayload.Subject);
            AccountGrade = Enum.Parse<AccountGrade>(jwtPayload.AccountGrade);
        }

        public int AccountId { get; }

        public AccountGrade AccountGrade { get; }
    }
}
