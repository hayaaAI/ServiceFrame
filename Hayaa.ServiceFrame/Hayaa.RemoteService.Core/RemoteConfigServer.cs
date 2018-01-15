using System;
using Hayaa.BaseModel;

namespace Hayaa.RemoteService.Core
{
    public class RemoteConfigServer : RemoteConfigService
    {
        public FunctionResult<AppConfig> SendConfig(Guid solutionID, int version)
        {
            throw new NotImplementedException();
        }
    }
}
