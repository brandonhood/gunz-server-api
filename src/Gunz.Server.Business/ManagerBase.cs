using AutoMapper;
using Gunz.Server.Business.Models;
using Gunz.Server.Common.CustomExceptions;
using Gunz.Server.Data;
using Microsoft.Extensions.Logging;

namespace Gunz.Server.Business
{
    internal abstract class ManagerBase
    {
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;
        protected readonly IGunzDatabaseContextFactory _gunzDatabaseContextFactory;

        protected ManagerBase(ILogger logger, IMapper mapper, IGunzDatabaseContextFactory gunzDatabaseContextFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _gunzDatabaseContextFactory = gunzDatabaseContextFactory;
        }

        protected void CheckAccountAccess(int accountId, RequestingAccountInfo requestingAccountInfo)
        {
            if (accountId != requestingAccountInfo.AccountId)
                throw new CustomAccountAccessException(requestingAccountInfo.AccountId, accountId);
        }
    }
}
