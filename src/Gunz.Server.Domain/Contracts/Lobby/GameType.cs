using System.Runtime.Serialization;

namespace Gunz.Server.Domain.Contracts.Lobby
{
    [DataContract]
    public class GameType
    {
        [DataMember]
        public int? GameTypeId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
