using Hayaa.ConfigSeed.Standard;


namespace Hayaa.ServicePlatform.Service.Config
{
    internal class ConfigHelper: ConfigTool<ServicePlatformServiceConfig, ServicePlatformServiceRootConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.ServicePlatformComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
