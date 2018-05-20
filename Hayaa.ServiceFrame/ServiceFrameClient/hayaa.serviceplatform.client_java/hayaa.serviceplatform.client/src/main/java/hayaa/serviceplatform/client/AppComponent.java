package hayaa.serviceplatform.client;

import java.util.List;

class AppComponent {
    private  int AppUserId;
    private int ComponetId;
    private String ComponentServiceCompeleteName;
    private String ComponentServiceName;
    private String ComponentAssemblyName;
    private String ComponentAssemblyFileName;
    private String ComponentAssemblyFileStorePath;
    private List<String> ComponentInterface;
    private String AssemblyVersion;

    public int getAppUserId() {
        return AppUserId;
    }

    public void setAppUserId(int appUserId) {
        AppUserId = appUserId;
    }

    public int getComponetId() {
        return ComponetId;
    }

    public void setComponetId(int componetId) {
        ComponetId = componetId;
    }

    public String getComponentServiceCompeleteName() {
        return ComponentServiceCompeleteName;
    }

    public void setComponentServiceCompeleteName(String componentServiceCompeleteName) {
        ComponentServiceCompeleteName = componentServiceCompeleteName;
    }

    public String getComponentServiceName() {
        return ComponentServiceName;
    }

    public void setComponentServiceName(String componentServiceName) {
        ComponentServiceName = componentServiceName;
    }

    public String getComponentAssemblyName() {
        return ComponentAssemblyName;
    }

    public void setComponentAssemblyName(String componentAssemblyName) {
        ComponentAssemblyName = componentAssemblyName;
    }

    public String getComponentAssemblyFileName() {
        return ComponentAssemblyFileName;
    }

    public void setComponentAssemblyFileName(String componentAssemblyFileName) {
        ComponentAssemblyFileName = componentAssemblyFileName;
    }

    public String getComponentAssemblyFileStorePath() {
        return ComponentAssemblyFileStorePath;
    }

    public void setComponentAssemblyFileStorePath(String componentAssemblyFileStorePath) {
        ComponentAssemblyFileStorePath = componentAssemblyFileStorePath;
    }

    public List<String> getComponentInterface() {
        return ComponentInterface;
    }

    public void setComponentInterface(List<String> componentInterface) {
        ComponentInterface = componentInterface;
    }

    public String getAssemblyVersion() {
        return AssemblyVersion;
    }

    public void setAssemblyVersion(String assemblyVersion) {
        AssemblyVersion = assemblyVersion;
    }


}
