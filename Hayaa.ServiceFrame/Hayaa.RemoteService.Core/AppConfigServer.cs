using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.RemoteService.DataAccess;

namespace Hayaa.RemoteService.Core
{
    public class AppConfigServer : AppConfigService
    {
        
        public FunctionResult<AppConfig> Create(AppConfig info)
        {
            var r = new FunctionResult<AppConfig>();
            int id= AppConfigDal.Add(info);
            if (id > 0)
            {
                r.Data = info;
                r.Data.ID = id;
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(AppConfig info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = AppConfigDal.update(info) > 0;
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = AppConfigDal.Delete(idList);
            return r;
        }

        public GridPager<AppConfig> GetPager(GridPagerPamater<AppConfigGridSearch> searchParam)
        {
            var r = AppConfigDal.GetGridPager(searchParam.PageSize, searchParam.Current, searchParam.SearchPamater.Title);
            return r;
        }

      
    }
}
