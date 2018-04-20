using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Client.Config
{
    /// <summary>
    /// 服务配置类
    /// </summary>
    [Serializable]
    internal class ServicePlatformServiceConfig : BaseData, ConfigContent
    {
        /// <summary>
        /// App的组件
        /// </summary>
       public List<AppComponent> Components { set; get; }

        /// <summary>
        /// App功能验证收集与验证地址
        /// </summary>
        public String AppServiceUrl { set; get; }
        /// <summary>
        /// 心跳与
        /// </summary>
        public String HeartServiceUrl { set; get; }
        /// <summary>
        /// 心跳间隔，单位秒
        /// </summary>
        public int HeartTimespan { set; get; }
        /// <summary>
        /// App默认执行用户Id
        /// </summary>
        public int DefaultAppUserId { set; get; }
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}
