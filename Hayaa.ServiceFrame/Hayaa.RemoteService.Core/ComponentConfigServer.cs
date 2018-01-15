using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;

namespace Hayaa.RemoteService.Core
{
    public class ComponentConfigServer : ComponentConfigService
    {
        public FunctionResult<ComponentConfig> Create(ComponentConfig info)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public GridPager<ComponentConfig> GetPager(GridPagerPamater<ComponentConfigGridSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult UpdateByID(ComponentConfig info)
        {
            throw new NotImplementedException();
        }
    }
}
