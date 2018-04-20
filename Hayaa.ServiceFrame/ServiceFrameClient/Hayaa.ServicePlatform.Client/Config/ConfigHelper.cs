using Hayaa.ConfigSeed.Standard;


namespace Hayaa.ServicePlatform.Client.Config
{
    internal class ConfigHelper: ConfigTool<ServicePlatformServiceConfig, ServicePlatformServiceRootConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.ServicePlatformClientComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
