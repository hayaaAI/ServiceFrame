package hayaa.serviceplatform.client;

public class AppAuthReponse {
    private int AppInstanceId;
    private String AppInstanceToken;

    public int getAppInstanceId() {
        return AppInstanceId;
    }

    public void setAppInstanceId(int appInstanceId) {
        AppInstanceId = appInstanceId;
    }

    public String getAppInstanceToken() {
        return AppInstanceToken;
    }

    public void setAppInstanceToken(String appInstanceToken) {
        AppInstanceToken = appInstanceToken;
    }


}
