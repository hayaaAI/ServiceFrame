using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeRepoService
{
    /// <summary>
    /// Git项目
    /// </summary>
   public class GitProject:BaseData
    {
        /// <summary>
        /// Git项目ID
        /// </summary>
        public int GitProjectID { set; get; }       
        /// <summary>
        /// 展示名称
        /// </summary>
        public String Title { set; get; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public String Name { set; get; }
        /// <summary>
        /// 不包括http的GIT网站地址
        /// </summary>
        public String SiteUrl { set; get; }
        /// <summary>
        /// 项目路径，不包括项目名
        /// </summary>
        public String ProjectPath { set; get; }
        
    }
}
