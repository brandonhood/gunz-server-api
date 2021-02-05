using Gunz.Server.Domain.Enums.Characters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Gunz.Server.Domain.Contracts.Characters
{
    [DataContract]
    public class Character
    {
        [DataMember]
        public int? CharacterId { get; set; }

        [DataMember]
        [Required]
        [MinLength(1)]
        [MaxLength(12)]
        public string Name { get; set; }

        [DataMember]
        public short? Level { get; set; }

        [DataMember]
        [Required]
        public CharacterSex? Sex { get; set; }
    }
}
