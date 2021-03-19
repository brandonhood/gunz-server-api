using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Gunz.Server.Domain.Contracts.Security
{
    [DataContract]
    public class ApiTokenRequest
    {
        [DataMember]
        [Required]
        public string Username { get; set; }

        [DataMember]
        [Required]
        public string Password { get; set; }
    }
}
