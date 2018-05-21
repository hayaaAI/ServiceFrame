package hayaa.serviceplatform.client;

import Hayaa.ConfigSeed.AppLocalConfig;
import Hayaa.ConfigSeed.AppSeed;
import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.TypeReference;
import hayaa.basemodel.model.FunctionOpenResult;
import hayaa.basemodel.model.TransactionResult;
import hayaa.common.HttpHelper;
import hayaa.common.JsonHelper;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class AppRoot {
    public static void StartApp() throws Exception {
        InitApp();

    }

    private static void InitApp() throws Exception {
        FunctionOpenResult<AppLocalConfig> config = AppSeed.GetAppLocalConfig();
        if(config.isActionResult()){
            if (config.getData().getRemoteConfigRoot())//远程配置服务和框架服务不执行App验证和实例获取
            {
                AppSeed.Instance().InitConfig();
                return;
            }
            Integer appId = config.getData().getAppID();
            Integer appInstanceId = config.getData().getAppInstanceID();
            Map<String,String> urlParamater = new HashMap<>();
            String response = null;
            urlParamater.put("t", config.getData().getSecurityToken());
            String strAppService =JsonHelper.SerializeObject(GetAppService(appId));
            urlParamater.put("appservice", strAppService);
            urlParamater.put("appinstanceid", appInstanceId.toString());
            response = HttpHelper.Transaction(ConfigHelper.instance().GetComponentConfig().getAppAuthServiceUrl(), urlParamater,"post");
            TransactionResult<AppAuthReponse> trAppService = (TransactionResult<AppAuthReponse>)JSON.parseObject(response, new TypeReference<TransactionResult<AppAuthReponse>>(){});
            if (trAppService.getCode() == 0)
            {
                if (appInstanceId == 0)
                {
                    appInstanceId = trAppService.getData().getAppInstanceId();
                    AppSeed.SetAppInstanceId(appInstanceId);
                }
                config.getData().setSecurityToken(trAppService.getData().getAppInstanceToken());//将APP的Token置换为实例Token，但是不保存至文件中
                AppSeed.Instance().InitConfig();
                //初始化授权数据
                //SecurityRoot.Init(appId);
                //启动心跳
                Heart.getInstance().Start(config.getData().getSecurityToken(), appInstanceId, appId);
            }
            else
            {
                throw new Exception(trAppService.getMessage());
            }
        }
    }

    private static List<AppService> GetAppService(Integer appId) {
        List<AppService> result =new ArrayList<>();
        return result;
    }
    public static int GetDefaultAppUser()
    {
        ServicePlatformServiceConfig config = ConfigHelper.instance().GetComponentConfig();
        if (config != null) return config.getDefaultAppUserId();
        return 0;
    }
    /// <summary>
    /// 重新加载配置文件
    /// </summary>
    public static void ReloadAppConfig()
    {
        AppSeed.Instance().Resetonfig();
    }
}
