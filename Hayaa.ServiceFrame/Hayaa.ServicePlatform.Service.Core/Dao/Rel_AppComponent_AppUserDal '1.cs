using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Config;

namespace Hayaa.ServicePlatform.Service.Dao
{
    internal partial class Rel_AppComponent_AppUserDal 
    {

        internal static Rel_AppComponent_AppUser Get(int appId, int appComponentId, int appUserId)
        {
            string sql = "select * from Rel_AppComponent_AppUser  where AppId=@AppId and AppComponentId=@AppComponentId and AppUserId=@AppUserId";
            return Get<Rel_AppComponent_AppUser>(con, sql, new {AppId=appId, AppComponentId=appComponentId,AppUserId=appUserId });
        }
    }
}