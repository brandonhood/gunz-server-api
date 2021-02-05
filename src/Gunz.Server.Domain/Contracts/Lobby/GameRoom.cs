using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gunz.Server.Domain.Contracts.Lobby
{
    [DataContract]
    public class GameRoom
    {
        [DataMember]
        public int? GameRoomId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public GameType GameType { get; set; }

        [DataMember]
        public int? PlayerLimit { get; set; }
    }
}
