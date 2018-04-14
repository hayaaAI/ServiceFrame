using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Dao;
using Hayaa.ServicePlatform.Service.Config;


namespace Hayaa.ServicePlatform.Service
{
    public partial class AppUserServer
    {
       public FunctionListResult<AppUser> GetList(int appId, string name)
        {
            var r = new FunctionListResult<AppUser>();
            r.Data = AppUserDal.GetList(appId, name);
            return r;
        }
    }
}