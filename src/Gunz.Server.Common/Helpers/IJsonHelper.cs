namespace Gunz.Server.Common.Helpers
{
    public interface IJsonHelper
    {
        T Deserialize<T>(string json);
    }
}
