namespace Gunz.Server.Data
{
    public interface IGunzDatabaseContextFactory
    {
        IGunzDatabaseContext CreateContext();
    }
}
