using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.CodeRepo.GogsHttpService.Config;
using Hayaa.Common;

namespace Hayaa.CodeRepo.GogsHttpService
{
    public class GogsServer : GogsService
    {
        private GogsConfig g_config = ConfigHelper.Instance.GetComponentConfig();
        public FunctionOpenResult<CreateGogsRepoResult> CreateGitRepo(CreateGogsRepoParamater repon, string gogsToken)
        {
            var r = new FunctionOpenResult<CreateGogsRepoResult>();
            String url = ConfigHelper.Instance.GetRequestUrl("user/repos", gogsToken);
            string httpReulst = null;
            try
            {
                httpReulst = HttpHelper.PostJson(JsonHelper.Serlaize<CreateGogsRepoParamater>(repon).Replace("isprivate", "private"), url);
            }catch(Exception ex)
            {
                r.ActionResult = false;
                r.ErrorMsg = String.Format("Gogs服务http请求失败,详细信息：{0}", ex.Message);
            }
            if (!string.IsNullOrEmpty(httpReulst))
            {
                httpReulst = httpReulst.Replace("private", "isprivate");
                try
                {
                    CreateGogsRepoResult data = JsonHelper.Deserialize<CreateGogsRepoResult>(httpReulst);
                    r.Data = data;
                }catch(Exception ex)
                {
                    r.ActionResult = false;
                    r.ErrorMsg = String.Format("Gogs返回结果json序列化失败,详细信息：{0}",ex.Message);
                }
            }
            return r;
        }
    }
}
