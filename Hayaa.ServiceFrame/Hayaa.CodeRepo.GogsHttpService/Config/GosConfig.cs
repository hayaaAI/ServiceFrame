using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeRepo.GogsHttpService.Config
{
    /// <summary>
    /// Gos服务配置文件
    /// </summary>
    [Serializable]
    internal  class GogsConfig:BaseData,ConfigContent
    {
        /// <summary>
        /// Gogs服务站点域名以及端口，不包括http
        /// </summary>
        public string SiteUrl { set; get; }
        /// <summary>
        /// Api路径
        /// </summary>
        public string ApiPath { set; get; }
        ///// <summary>
        ///// http请求路径模板
        ///// 数据模板:http://{SiteUrl}/{ApiPath}/{ApiName}
        ///// </summary>
        //public string RequestUrlTemplate { set; get; }
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}
