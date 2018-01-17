using Hayaa.BaseModel;
using System;

namespace Hayaa.CodeRepo.GogsHttpService
{
    /// <summary>
    /// gogs服务
    /// </summary>
    public interface GogsService
    {
        /// <summary>
        /// 通过webapi创建仓库
        /// </summary>
        /// <param name="repon">api接口需要的参数</param>
        /// <param name="gogsToken">gogs的用户令牌</param>
        /// <returns></returns>
        FunctionOpenResult<CreateGogsRepoResult> CreateGitRepo(CreateGogsRepoParamater repon,string gogsToken);
    }
}
