using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayaa.RemoteConfigClient.Model
{
    /// <summary>
    /// 宿主程序配置方案
    /// </summary>
    [Serializable]
   public class AppConfig
    {      
        /// <summary>
        /// 配置数据ID
        /// </summary>	
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 解决方案ID
        /// </summary>	
        public Guid SolutionID
        {
            get;
            set;
        }
        /// <summary>
        /// 解决方案名称
        /// </summary>	
         public string SolutionName
        {
            get;
            set;
        }
        /// <summary>
        /// 方案配置
        /// </summary>	
        public string ConfigContent
        {
            get;
            set;
        }
        
        /// <summary>
        /// 程序配置方案版本 
        /// </summary>
        public int Version
        {
            get;
            set;
        }
        /// <summary>
        /// 程序组件配置内容
        /// </summary>
        public List<ComponentConfig> Components { get; set; }
       
       
    }
}
