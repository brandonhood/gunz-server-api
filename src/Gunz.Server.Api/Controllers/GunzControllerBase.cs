using Gunz.Server.Api.CustomFilters;
using Gunz.Server.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gunz.Server.Api.Controllers
{
    [TypeFilter(typeof(BearerTokenFilter))]
    public abstract class GunzControllerBase : ControllerBase
    {
        protected RequestingAccountInfo GetRequestingAccountInfo()
            => (RequestingAccountInfo)HttpContext.Items["RequestingAccountInfo"];
    }
}
