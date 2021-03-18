using System.Text.Json;

namespace Gunz.Server.Common.Helpers
{
    internal class JsonHelper : IJsonHelper
    {
        private static readonly JsonSerializerOptions DefaultOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        public T Deserialize<T>(string json)
            => JsonSerializer.Deserialize<T>(json, DefaultOptions);
    }
}
