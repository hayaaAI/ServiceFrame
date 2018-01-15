﻿using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// 程序组件配置方案
    /// </summary>
    [Serializable]
    public class ComponentConfig : BaseData
    {
        /// <summary>
        /// ID
        /// </summary>		

        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 组件配置ID
        /// </summary>	

        public int ComponentConfigID
        {
            get;
            set;
        }
        /// <summary>
        /// 组件ID
        /// </summary>		

        public int ComponentID
        {
            get;
            set;
        }
        /// <summary>
        /// 组件配置内容
        /// </summary>		

        public string Content
        {
            get;
            set;
        }
        /// <summary>
        /// 配置内容版本
        /// </summary>	

        public int Version
        {
            get;
            set;
        }
        /// <summary>
        /// 配置标题
        /// </summary>

        public string ComponentConfigTitle { get; set; }
        /// <summary>
        /// 是否默认配置方案
        /// </summary>
        public bool IsDefault { set; get; }
    }
}
