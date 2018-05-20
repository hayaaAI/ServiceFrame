package hayaa.serviceplatform.client;

import java.io.Serializable;

class AppFunction implements Serializable {
    private int AppFuntionId;
    private String FunctionName;
    private String PathName;
    private String Title;
    private byte Status;
    private int AppServiceId;

    public int getAppFuntionId() {
        return AppFuntionId;
    }

    public void setAppFuntionId(int appFuntionId) {
        AppFuntionId = appFuntionId;
    }

    public String getFunctionName() {
        return FunctionName;
    }

    public void setFunctionName(String functionName) {
        FunctionName = functionName;
    }

    public String getPathName() {
        return PathName;
    }

    public void setPathName(String pathName) {
        PathName = pathName;
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public byte getStatus() {
        return Status;
    }

    public void setStatus(byte status) {
        Status = status;
    }

    public int getAppServiceId() {
        return AppServiceId;
    }

    public void setAppServiceId(int appServiceId) {
        AppServiceId = appServiceId;
    }


}
