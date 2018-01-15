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

        public FunctionOpenResult<bool> DeleteByID(int ID)
        {
            var r = new FunctionOpenResult<bool>();
           // r.Data = AppDal.Delete(idList);
            return r;
        }

        public GridPager<App> GetPager(GridPagerPamater<AppGridSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public FunctionOpenResult<bool> UpdateByID(App info)
        {
            throw new NotImplementedException();
        }
    }
}
