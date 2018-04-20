using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.Redis.Client.Model
{
    [Serializable]
    class RedisConfig
    {
        /// <summary>
        /// Redis配置名
        /// </summary>
        public String Name { set; get; }
        /// <summary>
        /// 访问地址
        /// 可以域名或者ip
        /// </summary>
        public String HostName { set; get; }
        /// <summary>
        /// 数据端口
        /// </summary>
        public int Port { set; get; }       
        public String ServerPwd { set; get; }
    }
}
