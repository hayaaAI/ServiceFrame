using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.RemoteService.DataAccess;

namespace Hayaa.RemoteService.Core
{
    public class ComponentConfigServer : ComponentConfigService
    {
     
        public FunctionResult<ComponentConfig> Create(ComponentConfig info)
        {
            var r = new FunctionResult<ComponentConfig>();
            int id = ComponentConfigDal.Add(info);
            if (id > 0)
            {
                r.Data = info;
                r.Data.ComponentConfigID = id;
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(ComponentConfig info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ComponentConfigDal.update(info) > 0;
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ComponentConfigDal.Delete(idList);
            return r;
        }

        public GridPager<ComponentConfig> GetPager(GridPagerPamater<ComponentConfigGridSearch> searchParam)
        {
            var r = ComponentConfigDal.GetGridPager(searchParam.PageSize, searchParam.Current, searchParam.SearchPamater.Title);
            return r;
        }
    }
}
