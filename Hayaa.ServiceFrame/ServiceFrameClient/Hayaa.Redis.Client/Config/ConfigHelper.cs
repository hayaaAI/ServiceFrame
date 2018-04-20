using Hayaa.ConfigSeed.Standard;


namespace Hayaa.Redis.Client.Config
{
    internal class ConfigHelper: ConfigTool<RedisClientConfig, RedisClientRootConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.RedisClientComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
