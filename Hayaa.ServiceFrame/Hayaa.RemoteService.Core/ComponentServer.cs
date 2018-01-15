using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.RemoteService.DataAccess;

namespace Hayaa.RemoteService.Core
{
    public class ComponentServer : ComponentService
    {
        public FunctionResult<Component> Create(Component info)
        {
            var r = new FunctionResult<Component>();
            int id = ComponentDal.Add(info);
            if (id > 0)
            {
                r.Data = info;
                r.Data.ComponentID = id;
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(Component info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ComponentDal.update(info) > 0;
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ComponentDal.Delete(idList);
            return r;
        }

        public GridPager<Component> GetPager(GridPagerPamater<ComponentGridSearch> searchParam)
        {
            var r = ComponentDal.GetGridPager(searchParam.PageSize, searchParam.Current, searchParam.SearchPamater.Title);
            return r;
        }
    }
}
