package hayaa.serviceplatform.client;

import Hayaa.ConfigSeed.ConfigTool;

class ConfigHelper extends ConfigTool<ServicePlatformServiceConfig, ServicePlatformServiceRootConfig> {
    private static ConfigHelper _instance = new ConfigHelper(DefineTable.ServicePlatformClientComponetID
            ,ServicePlatformServiceConfig.class,ServicePlatformServiceRootConfig.class);
    private ConfigHelper(int componentID, Class<ServicePlatformServiceConfig> componentConfigType,
                        Class<ServicePlatformServiceRootConfig> appRootConfigType) {
        super(componentID, componentConfigType, appRootConfigType);
    }
    public static ConfigHelper get_instance() {
        return _instance;
    }

}
