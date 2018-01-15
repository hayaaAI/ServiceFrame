using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteService.Core.Config
{
    /// <summary>
    /// 服务配置类
    /// </summary>
    [Serializable]
    class RemoteServiceConfig:BaseData, ConfigContent
    {
       
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}
