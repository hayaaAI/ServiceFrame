using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.RemoteService.DataAccess;

namespace Hayaa.RemoteService.Core
{
    public class AppServer : AppService
    {
        public FunctionResult<App> Create(App info)
        {
            var r = new FunctionResult<App>();
            int id = AppDal.Add(info);
            if (id > 0)
            {
                r.Data = info;
                r.Data.AppID = id;
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(App info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = AppDal.update(info) > 0;
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
             r.Data = AppDal.Delete(idList);
            return r;
        }

        public GridPager<App> GetPager(GridPagerPamater<AppGridSearch> searchParam)
        {
            var r =  AppDal.GetGridPager(searchParam.PageSize, searchParam.Current, searchParam.SearchPamater.Title);
            return r;
        }

      
    }
}
