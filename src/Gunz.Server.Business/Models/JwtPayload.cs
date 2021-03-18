using System.Text.Json.Serialization;

namespace Gunz.Server.Business.Models
{
    public class JwtPayload
    {
        [JsonPropertyName("sub")]
        public string Subject { get; set; }

        [JsonPropertyName("grade")]
        public string AccountGrade { get; set; }

        [JsonPropertyName("exp")]
        public long ExpiresAt { get; set; }
    }
}
