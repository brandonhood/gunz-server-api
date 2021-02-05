using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gunz.Server.Data.Models.Accounts
{
    [Table("Login")]
    public class LoginInfo
    {
        [Column("AID")]
        public int AccountId { get; set; }

        [Key]
        [Column("UserID")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
