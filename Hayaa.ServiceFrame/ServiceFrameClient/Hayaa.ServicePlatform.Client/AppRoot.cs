using Hayaa.ConfigSeed.Standard;
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
