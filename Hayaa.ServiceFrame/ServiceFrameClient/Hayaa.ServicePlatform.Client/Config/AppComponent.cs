using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Client.Config
{
    [Serializable]
    class AppComponent
    {
        public int ComponentInstanceID
        {
            get;
            set;
        }
        /// <summary>
        /// 程序用户ID
        /// </summary>	
        public int AppUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 组件ID
        /// </summary>		
        public int ComponetID
        {
            get;
            set;
        }
        /// <summary>
        /// 服务接口实现类完全限定名
        /// 形式："类名, 程序集名, Version=1.0.0, Culture=neutral, PublicKeyToken=null"
        /// </summary>	
        public string ComponentServiceCompeleteName
        {
            get;
            set;
        }
        /// <summary>
        /// 服务接口实现类名
        ///  形式："类名"
        /// </summary>	
        public string ComponentServiceName
        {
            get;
            set;
        }
        /// <summary>
        /// 程序集名称
        /// </summary>	
        public string ComponentAssemblyName
        {
            get;
            set;
        }
        /// <summary>
        /// 程序集文件名称
        /// </summary>	
        public string ComponentAssemblyFileName
        {
            get;
            set;
        }
        /// <summary>
        /// 程序集文件存储路径
        /// 绝对路径
        /// </summary>	
        public string ComponentAssemblyFileStorePath
        {
            get;
            set;
        }
        /// <summary>
        /// 接口名称
        /// </summary>
        public List<string> ComponentInterface
        {
            set;get;

        }
        public string ComponentInterfaces
        {
            set;
            get;
        }
        /// <summary>
        /// 程序集版本
        /// </summary>		

        public string AssemblyVersion
        {
            get;
            set;
        }
    }
}
