using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Config;


namespace Hayaa.ServicePlatform.Service.Dao
{
    internal partial class AppUserDal
    {
        internal static List<AppUser> GetList(int appId, String name)
        {
            string sql = "select au.* from AppUser as au inner join Rel_AppComponent_AppUser as racau on au.AppUserId=racau.AppUserId and racau.AppId=@AppId where au.Name like '%@Name%'";
            return GetList<AppUser>(con, sql, new { AppId = appId, Name = name });
        }
    }
}  