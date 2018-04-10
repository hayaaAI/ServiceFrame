using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Service.Config
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
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}
