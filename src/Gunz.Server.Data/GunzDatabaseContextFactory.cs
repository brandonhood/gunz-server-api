namespace Gunz.Server.Data
{
    public class GunzDatabaseContextFactory : IGunzDatabaseContextFactory
    {
        public IGunzDatabaseContext CreateContext()
            => new GunzDatabaseContext();
    }
}
