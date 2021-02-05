using System.Runtime.Serialization;

namespace Gunz.Server.Domain.Contracts.Security
{
    [DataContract]
    public class ApiTokenResponse
    {
        [DataMember]
        public string AccessToken { get; set; }

        [DataMember]
        public int AccountId { get; set; }
    }
}
