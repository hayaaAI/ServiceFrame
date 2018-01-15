using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfigClient
{
    /// <summary>
    /// 配置工具类
    /// 配置管理继承基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConfigTool<T> where T :BaseData, ConfigContent, new()
    {
        private T g_config;
        public ConfigTool(int componentID)
        {
            FunctionResult<T> Config = RemoteConfigClient.GetConfig<T>(componentID);
            if (Config.ActionResult & Config.HavingData)
            {
                g_config = Config.Data;
            }
        }

        public T GetComponentConfig()
        {
            return g_config;
        }
        private string _ConfigExceptionMsg = "";
        public string IsConfigExceptionMsg
        {
            get
            {
                if (g_config == null)
                    _ConfigExceptionMsg = "配置内容为空";
                return _ConfigExceptionMsg;
            }
        }
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public string GetConnection(string name)
        {
           
            return GetCon(name);
        }
        private string GetCon(string name)
        {
            var baseConfig = (ConfigContent)g_config;
            var con = baseConfig.ConnectionStrings.Settings.Find(c => c.Name == name);            
            return con.Connection;
        }
        /// <summary>
        /// 获取AppSetting配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public string GetAppsetting(string key, string defaultVal)
        {           
            return GetAppset(key, defaultVal);
        }
        private string GetAppset(string key, string defaultVal)
        {
            var baseConfig = (ConfigContent)g_config;
            var con = baseConfig.AppSettings.Settings.Find(c => c.Key == key);
            if (con != null) return con.Value;
            return defaultVal;
        }
    }
}
