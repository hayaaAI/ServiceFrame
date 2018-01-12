using Hayaa.BaseModel;
using Hayaa.Common;
using System;

namespace Hayaa.RemoteConfigClient
{
    /// <summary>
    /// 远程配置管理客户端
    /// </summary>
    public class RemoteConfigClient
    {
        private static RemoteConfigClient g_instance = new RemoteConfigClient();
        public static RemoteConfigClient Instance
        {
            get
            {
                return g_instance;
            }
        }
        /// <summary>
        /// 程序配置初始化
        /// </summary>
        /// <returns></returns>
        public BaseFunctionResult AppConfigInit()
        {
            var result = new BaseFunctionResult();
            try
            {

                  //分布式配置系统则获取配置
                ProgramDistributedConfig.Instance.RunInAppStartInit();
               
            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message;
                result.ActionResult = false;
            }
            return result;
        }
        /// <summary>
        /// 重置配置
        /// </summary>
        /// <returns></returns>
        public BaseFunctionResult ResetConfig()
        {
            return AppConfigInit();
        }
       
        /// <summary>
        /// 远程配置变更触发器
        /// </summary>
        /// <returns></returns>
        public BaseFunctionResult RemoteTrigger()
        {
            return AppConfigInit();
        }     
        /// <summary>
        /// 按照组件ID获取组件配置内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentID"></param>
        /// <returns></returns>
        public static FunctionResult<T> GetConfig<T>(int componentID) where T:BaseData
        {
            var r = new FunctionResult<T>();
            var config = ProgramDistributedConfig.Instance.GetComponentConfig(componentID);
            if (config != null)
            {
                if (string.IsNullOrEmpty(config.Content))
                {
                    r.Data= JsonHelper.Deserialize<T>(config.Content);
                }
            }
            return r;
        }
    }
}
