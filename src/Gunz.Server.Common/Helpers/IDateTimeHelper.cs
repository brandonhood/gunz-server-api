using System;

namespace Gunz.Server.Common.Helpers
{
    public interface IDateTimeHelper
    {
        DateTime GetUtcNow();

        long GetSecondsSinceEpoch(DateTime input);
    }
}
