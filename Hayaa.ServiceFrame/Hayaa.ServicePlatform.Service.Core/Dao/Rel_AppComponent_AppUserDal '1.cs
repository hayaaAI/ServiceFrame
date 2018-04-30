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
        internal static List<Rel_AppComponent_AppUser> GetList(int appId, int componentId, int appUserId)
        {
            string sql = "select raca.* from Rel_AppComponent_AppUser as raca inner join AppComponent as ac on raca.AppComponentId=ac.AppComponentId and ac.ComponentId=@ComponentId  where raca.AppId=@AppId  and raca.AppUserId=@AppUserId";
            return GetList<Rel_AppComponent_AppUser>(con, sql, new { AppId = appId, ComponentId = componentId, AppUserId = appUserId });
        }
        internal static int Delete(int appId, int componentId)
        {
            string sql = "delete from  Rel_AppComponent_AppUser where AppId=@AppId and AppComponentId in(select AppComponentId from AppComponent where ComponentId=@ComponentId)";
            return Excute(con, sql, new { AppId = appId, ComponentId = componentId });
        }
    }
}