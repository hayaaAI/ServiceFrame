using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;

namespace Hayaa.RemoteService.Core
{
    public class AppConfigServer : AppConfigService
    {
        public FunctionResult<AppConfig> Create(AppConfig info)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public GridPager<AppConfig> GetPager(GridPagerPamater<AppConfigGridSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult UpdateByID(AppConfig info)
        {
            throw new NotImplementedException();
        }
    }
}
