using Gunz.Server.Data.Models.Accounts;
using Gunz.Server.Data.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace Gunz.Server.Data
{
    public sealed class GunzDatabaseContext : DbContext, IGunzDatabaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=GunzDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #region DbSets

        public DbSet<CharacterModel> Characters { get; private set; }

        public DbSet<LoginInfo> LoginInfos { get; private set; }

        #endregion
    }
}
