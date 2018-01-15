using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// 远程配置服务
    /// </summary>
   public interface RemoteConfigService
    {
        /// <summary>
        /// 发送制定的App(宿主程序)配置方案内容
        /// </summary>
        /// <param name="solutionID">方案ID</param>
        /// <param name="version">方案版本</param>
        /// <returns>包括组件配置列表的app配置方案数据实体</returns>
        FunctionResult<AppConfig> SendConfig(Guid solutionID, int version);
      
    }
}
