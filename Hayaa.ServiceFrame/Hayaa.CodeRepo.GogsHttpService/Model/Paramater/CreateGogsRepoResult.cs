using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.CodeRepo.GogsHttpService
{
    /// <summary>
    /// 创建仓库返回结果
    /// </summary>
    [Serializable]
    public class CreateGogsRepoResult
    {
        public int id { set; get; }
        public RepoOwer owner { set; get; }

        public class RepoOwer
        {
            public int id { set; get; }
            public string username { set; get; }
            public string full_name { set; get; }
            public string email { set; get;}
            public string avatar_url { set; get; }
        }
        public string full_nmae { set; get; }
        public bool isprivate { set; get; }
        public string fork { set; get; }
        public string html_url { set; get; }
        public string clone_url { set; get; }
        public string ssh_url { set; get; }
        public Persmissions permissions { set; get; }

        public class Persmissions
        {
            public bool admin { set; get; }
            public bool push { set; get; }
            public bool pull { set; get; }
        }
    }
}
