using System;

namespace Gunz.Server.Common.Helpers
{
    internal class DateTimeHelper : IDateTimeHelper
    {
        private static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public long GetSecondsSinceEpoch(DateTime input)
            => (long)input.Subtract(UnixEpoch).TotalSeconds;

        public DateTime GetUtcNow()
            => DateTime.UtcNow;
    }
}
