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
        public static List<AppService> g_authorityData = null;
        /// <summary>
        /// 启动APP，加载配置文件
        /// </summary>
        public static void StartApp()
        {           
            InitApp();
        }
        /// <summary>
        /// 申请App实例Id
        /// 置换token
        /// 获取远程配置
        /// </summary>
        private static void InitApp()
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
                urlParamater.Add("t", config.Data.SecurityToken);
                String strAppService = JsonHelper.Serlaize<List<AppService>>(GetAppService(appId));
                urlParamater.Add("appservice", strAppService);
                urlParamater.Add("appinstanceid", appInstanceId.ToString());
                response = httpHelper.Transaction(ConfigHelper.Instance.GetComponentConfig().AppServiceUrl, urlParamater);
                TransactionResult<AppAuthReponse> trAppService = JsonHelper.DeserializeSafe<TransactionResult<AppAuthReponse>>(response);
                if (trAppService.Code == 0)
                {
                    if (appInstanceId == 0)
                    {
                        appInstanceId = trAppService.Data.AppInstanceId;
                        AppSeed.SetAppInstanceId(appInstanceId);
                    }
                    config.Data.SecurityToken = trAppService.Data.AppInstanceToken;//将APP的Token置换为实例Token，但是不保存至文件中
                    AppSeed.Instance.InitConfig();
                    g_authorityData = GetAuthority(appId, httpHelper);
                }
                else
                {
                    throw new Exception(trAppService.Message);
                }

               
            }
        }

        private static List<AppService> GetAuthority(int appId, HttpRequestHelper httpHelper)
        {
            List<AppService> result = null;
            var urlParamater = new Dictionary<string, string>();
            String response = httpHelper.Transaction(ConfigHelper.Instance.GetComponentConfig().AppSecurityUrl, urlParamater);
            TransactionResult<List<AppService>> serverResult = JsonHelper.DeserializeSafe<TransactionResult<List<AppService>>>(response);
            if (serverResult.Code == 0)
            {
                result = serverResult.Data;
            }
            else
            {
                throw new Exception(serverResult.Message);
            }          
            return result;
        }

        private static List<AppService> GetAppService(int appId)
        {
            List<AppService> result = new List<AppService>();
            Assembly[] arr = AppDomain.CurrentDomain.GetAssemblies();
            if (arr != null)
            {
                foreach (var a in arr)
                {
                    if (a.FullName.Contains("Controller"))//只遍历符合框架规定的程序集
                    {
                        Type[] typeList = a.GetTypes();
                        foreach (var t in typeList)
                        {
                            if (t.Name.Contains("Controller"))
                            {
                                var appService = new AppService()
                                {
                                    AppId = appId,
                                    Name = t.Name
                                };
                                MethodInfo[] methods = t.GetMethods();
                                if (methods != null)
                                {
                                    appService.AppFunctions = new List<AppFunction>();
                                    foreach (var m in methods)
                                    {
                                        appService.AppFunctions.Add(new AppFunction()
                                        {
                                            FunctionName = m.Name,
                                            PathName = m.Name,
                                            Status = 0
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
            ServicePlatformServiceConfig config = ConfigHelper.Instance.GetComponentConfig();
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
