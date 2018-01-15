﻿using System;
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

        public FunctionOpenResult<bool> DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public GridPager<AppConfig> GetPager(GridPagerPamater<AppConfigGridSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public FunctionOpenResult<bool> UpdateByID(AppConfig info)
        {
            throw new NotImplementedException();
        }
    }
}
