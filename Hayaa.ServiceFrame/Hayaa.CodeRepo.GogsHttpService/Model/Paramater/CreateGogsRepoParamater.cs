using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeRepo.GogsHttpService
{
    /// <summary>
    /// 创建Gogs的仓库参数
    /// </summary>
    [Serializable]
    public  class CreateGogsRepoParamater
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 仓库说明
        /// </summary>
        public string description { set; get; }
        /// <summary>
        /// 是否私有
        /// 序列化的参数名称为private
        /// </summary>        
        public bool isprivate { set; get; }
        /// <summary>
        /// 初始化库文件与否
        /// </summary>
        public bool auto_init { set; get; }
        /// <summary>
        /// 需要忽略文件
        /// </summary>
        public string gitignores { set; get; }
        /// <summary>
        /// 版权说明
        /// </summary>
        public string license { set; get; }
        /// <summary>
        /// readme文件
        /// </summary>
        public string readme { set; get; }
    }
}
