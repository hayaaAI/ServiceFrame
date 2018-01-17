using Hayaa.CodeRepo.GogsHttpService.Config;
using Hayaa.RemoteConfigClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeRepo.GogsHttpService.Config
{
    internal class ConfigHelper: ConfigTool<GogsConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.CodeRepoComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
        /// <summary>
        /// 获取gogs服务的api请求路径
        /// </summary>
        /// <param name="apiName"></param>
        /// <returns></returns>
        internal string GetRequestUrl(string apiName,String token)
        {
            var config = this.GetComponentConfig();
            String url = String.Format("{0}/{1}/{2}?token={3}", config.SiteUrl, config.ApiPath, apiName, token).Replace("//","/");
            return string.Format("http://{0}",url);
        }
    }
}
