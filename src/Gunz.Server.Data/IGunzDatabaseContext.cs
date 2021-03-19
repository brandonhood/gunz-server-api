using Gunz.Server.Data.Models.Accounts;
using Gunz.Server.Data.Models.Characters;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gunz.Server.Data
{
    public interface IGunzDatabaseContext : IAsyncDisposable
    {
        DbSet<CharacterModel> Characters { get; }

        DbSet<LoginInfo> LoginInfos { get; }
    }
}
