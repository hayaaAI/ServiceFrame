package hayaa.serviceplatform.client;

import java.io.Serializable;
import java.util.List;

class AppService implements Serializable {
    private int AppServiceId;
    private String Name;
    private String Title;
    private int AppId;
    private List<AppFunction> AppFunctions;

    public int getAppServiceId() {
        return AppServiceId;
    }

    public void setAppServiceId(int appServiceId) {
        AppServiceId = appServiceId;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public int getAppId() {
        return AppId;
    }

    public void setAppId(int appId) {
        AppId = appId;
    }

    public List<AppFunction> getAppFunctions() {
        return AppFunctions;
    }

    public void setAppFunctions(List<AppFunction> appFunctions) {
        AppFunctions = appFunctions;
    }


}
