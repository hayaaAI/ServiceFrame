using Hayaa.ConfigSeed.Standard;
using Hayaa.ServicePlatform.Client.Config;
using Hayaa.ServicePlatform.Client.Util;
using System;
using System.Collections.Generic;
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
            var config = AppSeed.GetAppId();
            if (config.ActionResult)
            {
                int appId = config.Data;
                //发送
                HttpRequestHelper httpHelper = new HttpRequestHelper();
                var urlParamater = new Dictionary<string, string>();
                urlParamater.Add("appid", appId.ToString());
                httpHelper.Transaction(ConfigHelper.Instance.GetComponentConfig().AppInstanceUrl, urlParamater);
            }
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
