package hayaa.serviceplatform.client;

import Hayaa.ConfigSeed.AppSeed;
import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.TypeReference;
import hayaa.basemodel.model.TransactionResult;
import hayaa.common.HttpHelper;
import hayaa.common.JsonHelper;

import java.util.*;

class Heart {
    public static Heart getInstance() {
        return instance;
    }

    private static Heart instance = new Heart();
    private static Timer g_timer = null;
    private String g_token;
    private Integer g_appInstanceId;
    private Integer g_appId;

    private void HeartAction() {
        String response = null;
        Map<String, String> urlParamater = new HashMap<String, String>();
        urlParamater.put("t", g_token);
        urlParamater.put("appinstanceid", g_appInstanceId.toString());
        urlParamater.put("appid", g_appId.toString());
        response = HttpHelper.Transaction(ConfigHelper.instance().GetComponentConfig().getHeartServiceUrl(), urlParamater, "post");
        try {
            TransactionResult<List<Integer>> serviceResult =(TransactionResult<List<Integer>>)JSON.parseObject(response, new TypeReference<TransactionResult<List<Integer>>>() {
            });
            if (serviceResult.getCode() == 0) {

                if (serviceResult.getData().contains(1)) {
                    AppSeed.Instance().Resetonfig();
                }
                if (serviceResult.getData().contains(2)) {
                    // SecurityRoot.Reset(g_appId);
                }
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
    public void Start(String token, int appInstanceId, int appId)
    {
        g_token = token;
        g_appInstanceId = appInstanceId;
        g_appId = appId;
        g_timer = new Timer();
        g_timer.schedule(new TimerTask() {
            @Override
            public void run() {
                HeartAction();
            }
        },60 * 1000,ConfigHelper.instance().GetComponentConfig().getHeartTimespan() * 1000*5  );
    }
}
