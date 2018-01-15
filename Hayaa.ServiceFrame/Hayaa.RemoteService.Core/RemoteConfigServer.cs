using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
using Hayaa.RemoteService.DataAccess;

namespace Hayaa.RemoteService.Core
{
    public class RemoteConfigServer : RemoteConfigService
    {
        public FunctionResult<AppConfig> SendConfig(Guid solutionID, int version)
        {
            var r = new FunctionResult<AppConfig>();
            var appConfig = AppConfigDal.Get(solutionID, version);
            if (appConfig != null)
            {
                List<ComponentConfig> list = ComponentConfigDal.GetList(appConfig.ID, appConfig.Version);
                appConfig.Components = list;
                r.Data = appConfig;
            }
            else
            {
                r.ErrorMsg = "无获取app的配置数据";
                r.Data = null;
            }
            return r;
        }
    }
}
