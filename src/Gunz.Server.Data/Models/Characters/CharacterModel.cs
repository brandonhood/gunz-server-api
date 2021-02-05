using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gunz.Server.Data.Models.Characters
{
    [Table("Character")]
    public class CharacterModel
    {
        [Key]
        [Column("CID")]
        public int CharacterId { get; set; }

        [Column("AID")]
        public int AccountId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Level")]
        public short Level { get; set; }

        [Column("CharNum")]
        public short Order { get; set; }

        [Column("Sex")]
        public byte Sex { get; set; }
    }
}
