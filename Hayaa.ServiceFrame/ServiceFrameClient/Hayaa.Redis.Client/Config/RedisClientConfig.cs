using Hayaa.BaseModel;
using Hayaa.Redis.Client.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.Redis.Client.Config
{
    /// <summary>
    /// 服务配置类
    /// </summary>
    [Serializable]
    internal class RedisClientConfig : BaseData, ConfigContent
    {
        public List<RedisConfig> RedisConfigs { set; get;  }
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }

    }
}
