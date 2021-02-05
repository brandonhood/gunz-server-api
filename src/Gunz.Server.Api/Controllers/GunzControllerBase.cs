using AutoMapper;
using Gunz.Server.Api.CustomExceptions;
using Gunz.Server.Api.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Gunz.Server.Api.Controllers
{
    [BearerTokenFilter]
    public abstract class GunzControllerBase : ControllerBase
    {
        #region Fields

        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        #endregion

        #region Constructor

        protected GunzControllerBase(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Helpers

        protected void CheckAccountAccess(int accountId)
        {
            if (accountId != GetAccountId())
                throw new CustomAccountAccessException(GetAccountId(), accountId);
        }

        protected int GetAccountId()
            => (int)HttpContext.Items["AccountId"];

        #endregion
    }
}
