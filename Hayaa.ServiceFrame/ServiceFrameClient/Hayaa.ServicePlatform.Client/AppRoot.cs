using Hayaa.BaseModel.Model;
using Hayaa.Common;
using Hayaa.ConfigSeed.Standard;
using Hayaa.ServicePlatform.Client.Config;
using Hayaa.ServicePlatform.Client.Model;
using Hayaa.ServicePlatform.Client.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Hayaa.ServicePlatform.Client
{
   public class AppRoot
    {
        /// <summary>
        /// 启动APP，加载配置文件
        /// </summary>
        public static void StartApp()
        {
            AppSeed.Instance.InitConfig();
            SendAppInstance();
        }

        private static void SendAppInstance()
        {
            //获取AppId
            var config = AppSeed.GetAppLocalConfig();
            if (config.ActionResult)
            {
                int appId = config.Data.AppID;
                int appInstanceId = config.Data.AppInstanceID;
                var urlParamater = new Dictionary<string, string>();
               
                HttpRequestHelper httpHelper = new HttpRequestHelper();
                String response = null;
                if (appInstanceId == 0)//未获取到实例Id发送请求
                {
                    urlParamater.Add("appid", appId.ToString());
                    response = httpHelper.Transaction(ConfigHelper.Instance.GetComponentConfig().AppInstanceUrl, urlParamater);
                    TransactionResult<int> tr = JsonHelper.DeserializeSafe<TransactionResult<int>>(response);
                    if (tr.Code == 0)
                    {
                        appInstanceId = tr.Data;
                    }
                    AppSeed.SetAppInstanceId(appInstanceId);
                }
                String strAppService = JsonHelper.Serlaize<List<AppService>>(GetAppService(appId));
                urlParamater.Clear();
                urlParamater.Add("appservice", strAppService);
                 response = httpHelper.Transaction(ConfigHelper.Instance.GetComponentConfig().AppServiceUrl, urlParamater);
                TransactionResult<Boolean> trAppService = JsonHelper.DeserializeSafe<TransactionResult<Boolean>>(response);
                if (trAppService.Code == 0)
                {
                  
                }

            }
        }
        private static List<AppService> GetAppService(int appId)
        {
            List<AppService> result = new List<AppService>();
            Assembly[] arr= AppDomain.CurrentDomain.GetAssemblies();
            if (arr != null)
            {
                foreach(var a in arr)
                {
                    if (a.FullName.Contains("Controller"))//只遍历符合框架规定的程序集
                    {
                        Type[] typeList = a.GetTypes();
                        foreach(var t in typeList)
                        {
                            if (t.Name.Contains("Controller"))
                            {
                                var appService = new AppService()
                                {
                                     AppId=appId,
                                      Name=t.Name
                                };
                                MethodInfo[] methods= t.GetMethods();
                                if (methods != null)
                                {
                                    appService.AppFunctions = new List<AppFunction>();
                                    foreach (var m in methods)
                                    {
                                        appService.AppFunctions.Add(new AppFunction() {
                                             FuntionName=m.Name,
                                              PathName=m.Name,
                                              Status=0
                                        });
                                    }
                                }
                                result.Add(appService);
                            }
                        }
                    }

                }
            }
            return result;
        }
        public static int GetDefaultAppUser()
        {
            ServicePlatformServiceConfig config= ConfigHelper.Instance.GetComponentConfig();
            if (config != null) return config.DefaultAppUserId;
            return 0;
        }
        /// <summary>
        /// 重新加载配置文件
        /// </summary>
        public static void ReloadAppConfig()
        {
            AppSeed.Instance.Resetonfig();
        }
        
    }
}
