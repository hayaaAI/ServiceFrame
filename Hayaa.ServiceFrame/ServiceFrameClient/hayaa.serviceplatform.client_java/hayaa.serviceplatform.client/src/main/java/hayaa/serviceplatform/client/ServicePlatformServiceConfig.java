package hayaa.serviceplatform.client;

import hayaa.basemodel.model.ConfigContent;

import java.io.Serializable;
import java.util.List;

class ServicePlatformServiceConfig extends ConfigContent implements Serializable {
    private List<AppComponent> Components;
    private String AppAuthServiceUrl;
    private String HeartServiceUrl;
    private int HeartTimespan;
    private int DefaultAppUserId;

    public List<AppComponent> getComponents() {
        return Components;
    }

    public void setComponents(List<AppComponent> components) {
        Components = components;
    }

    public String getAppAuthServiceUrl() {
        return AppAuthServiceUrl;
    }

    public void setAppAuthServiceUrl(String appAuthServiceUrl) {
        AppAuthServiceUrl = appAuthServiceUrl;
    }

    public String getHeartServiceUrl() {
        return HeartServiceUrl;
    }

    public void setHeartServiceUrl(String heartServiceUrl) {
        HeartServiceUrl = heartServiceUrl;
    }

    public int getHeartTimespan() {
        return HeartTimespan;
    }

    public void setHeartTimespan(int heartTimespan) {
        HeartTimespan = heartTimespan;
    }

    public int getDefaultAppUserId() {
        return DefaultAppUserId;
    }

    public void setDefaultAppUserId(int defaultAppUserId) {
        DefaultAppUserId = defaultAppUserId;
    }



}
