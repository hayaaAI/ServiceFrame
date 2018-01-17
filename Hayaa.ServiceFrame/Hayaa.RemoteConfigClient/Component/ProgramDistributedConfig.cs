
using Hayaa.Common;
using Hayaa.RemoteConfigClient.Config;
using Hayaa.RemoteConfigClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Hayaa.RemoteConfigClient
{
   internal class ProgramDistributedConfig
    {
        private AppConfig _appConfig;
        private AppLocalConfig _seedConfig;
        private static ProgramDistributedConfig _instance = new ProgramDistributedConfig();

        internal static ProgramDistributedConfig Instance
        {
            get
            {
                return _instance;
            }


        }

        private ProgramDistributedConfig()
        {
            _appConfig = new AppConfig()
            {
                Components = new List<ComponentConfig>(),
                ConfigContent = "",
                SolutionID = Guid.Empty,               
                SolutionName = "本地配置",
                Version = 0,
            };//构造函数默认对象内属性数值，默认为本地模式参数
            try
            {
                _seedConfig = ReadSeedConfig();//防止基础配置不存在或者错误导致程序无法启动
            }
            catch (Exception ex)
            {
                _seedConfig = new AppLocalConfig() { Version = 0, AppConfigID = Guid.Empty, IsRemote = false };//错误配置下给予最小化配置               
            }
        }

        /// <summary>
        /// 本地配置模式下只有一个方案序列化文件
        /// </summary>
        /// <param name="seedConfig"></param>
        private void ReadLocal(AppLocalConfig seedConfig, InitResult result)
        {
            if (string.IsNullOrEmpty(seedConfig.LocalConfigDirectoryPath))//如果没有默认路径不读取
            {
                result.Result = false;
                result.Message = "本地配置文件路径为空";
                return;//构造函数里默认数值
            }
            try
            {
                var temp =JsonHelper.Deserialize<AppConfig>(File.ReadAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName));
                if (temp != null)//使用构造函数里的数值，避免多位置同效代码赋值
                {
                    _appConfig = temp;
                }
            }
            catch (Exception ex)//预期异常：格式错误，错误内容
            {
                result.Result = false;
                result.Message = ex.Message;
                return;
            }

        }
        /// <summary>
        /// 读取程序的配置
        /// </summary>
        /// <param name="seedConfig"></param>
        /// <returns></returns>
        private AppConfig ReadLocal(AppLocalConfig seedConfig)
        {
            if (string.IsNullOrEmpty(seedConfig.LocalConfigDirectoryPath))//如果没有默认路径和默认文件配置不读取
            {
                return null;//构造函数里默认数值
            }
            try
            {
                var temp = JsonHelper.Deserialize<AppConfig>(File.ReadAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName));
                return temp;
            }
            catch (Exception ex)//预期异常：格式错误，错误内容
            {

            }
            return null;
        }
        /// <summary>
        /// 远程获取程序配置
        /// </summary>
        /// <param name="seedConfig"></param>
        private void ReadRemote(AppLocalConfig seedConfig)
        {

           
                AppConfig localconfig = null;
            //判断配置文件是否已经存在
            if (File.Exists(seedConfig.LocalConfigDirectoryPath + "/app.json"))
            {
                localconfig = ReadLocal(seedConfig);
            }
            
                //远程拉取配置文件
                var remoteConfig = GetRemote(seedConfig.ServerUrl, seedConfig.AppConfigID);
                //判断配置文件的新鲜程度
                if (remoteConfig != null)//无法获取远程配置时不更新本地
                {
                    if (seedConfig.Version == 0)//永远最新
                    {
                        File.Delete(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName);
                        //固化指定目录下制定的文件
                        File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName,JsonHelper.Serlaize<AppConfig>(remoteConfig));
                     }
                    if ((seedConfig.Version > 0) && (localconfig == null))//本地没有配置文件并且不是永远更新
                    {
                        File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName, JsonHelper.Serlaize<AppConfig>(remoteConfig));
                    }
            }
            
        }
        private AppConfig GetRemote(string url, Guid solutionID)
        {
            var dic = new Dictionary<string, string>();
            dic.Add(DefineTable.UrlAction, DefineTable.GetRmoteConfigAction);
            dic.Add(DefineTable.SolutionIDParam, solutionID.ToString());
            string str = "";
            AppConfig result = null;
            try
            {
                 str =HttpHelper.HttpRequest(url, dic);
                //str = HttpUtility.UrlDecode(str);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<AppConfig>(str);
            }
            catch (Exception ex)
            {
                result = null;
                return result;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private AppLocalConfig ReadSeedConfig()
        {
            AppLocalConfig r = new AppLocalConfig()
            {
                 IsRemote = true,
                IsVirtualPath = true,
                LocalConfigDirectoryPath = "~/Config",
                Version = 0
            };
            try
            {
                string baseDirectory =  AppDomain.CurrentDomain.BaseDirectory;//获取根目录路径
                r=JsonHelper.Deserialize<AppLocalConfig>(File.ReadAllText(baseDirectory + "/appconfig.json"));//读取根目录下的配置文件
                if (r.IsVirtualPath)//web系统相对部署根目录获取绝对路径
                {
                    r.LocalConfigDirectoryPath =baseDirectory+r.LocalConfigDirectoryPath.Replace("~/","");
                }
            }
            catch (Exception ex)
            {
                r = new AppLocalConfig() { IsVirtualPath = false };
            }
           
            return r;
        }
        public AppConfig GetLocalConfig()
        {
            return ReadLocal(_seedConfig);
        }
        public bool IsEmpty()
        {
            if (_appConfig.SolutionID.Equals(Guid.Empty))
            {
                return true;
            }
            return false;
        }
       /// <summary>
        /// 在程序第一次运行时运行此方法获取配置
        /// </summary>
        /// <returns></returns>
        public InitResult RunInAppStartInit()
        {
            var r = new InitResult() { Result = true };
            if (_seedConfig.IsRemote)//判断是否读取远程配置模式
            {
                ReadRemote(_seedConfig);//读取远程配置
            }
            ReadLocal(_seedConfig, r);//读取本地配置 
            return r;
        }
        public ComponentConfig GetComponentConfig(int componetID)
        {
            //构造函数完成无null初始化设置
            return _appConfig.Components.Find(c => c.ComponentID == componetID);
        }
         public AppLocalConfig GetSeedConfig()
        {
            return _seedConfig;
        }
    }
    internal class InitResult
    {
        public bool Result { set; get; }
        public string Message { set; get; }
    }
}
