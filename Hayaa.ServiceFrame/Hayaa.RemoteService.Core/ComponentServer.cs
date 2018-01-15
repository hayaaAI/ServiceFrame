using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;

namespace Hayaa.RemoteService.Core
{
   public class ComponentServer : ComponentService
    {
        public FunctionResult<Component> Create(Component info)
        {
            throw new NotImplementedException();
        }

        public FunctionOpenResult<bool> DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public GridPager<Component> GetPager(GridPagerPamater<ComponentGridSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public FunctionOpenResult<bool> UpdateByID(Component info)
        {
            throw new NotImplementedException();
        }
    }
}
