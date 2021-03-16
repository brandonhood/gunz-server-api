using AutoMapper;
using Gunz.Server.Business.Models;
using Gunz.Server.Common.CustomExceptions;
using Microsoft.Extensions.Logging;

namespace Gunz.Server.Business
{
    internal abstract class ManagerBase
    {
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;

        protected ManagerBase(ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        protected void CheckAccountAccess(int accountId, RequestingAccountInfo requestingAccountInfo)
        {
            if (accountId != requestingAccountInfo.AccountId)
                throw new CustomAccountAccessException(requestingAccountInfo.AccountId, accountId);
        }
    }
}
