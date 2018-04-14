using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Config;


namespace Hayaa.ServicePlatform.Service.Dao
{
    internal partial class AppComponentDal 
    {
        internal static List<AppComponent> GetList(int appId, String name)
        {
            string sql = "select ac.* from AppComponent as ac inner join Rel_AppComponent_AppUser as racau on ac.AppComponentId=racau.AppComponentId and racau.AppId=@AppId where ac.Name like '%@Name%'";
            return GetList<AppComponent>(con, sql, new { AppId=appId,Name=name });
        }
    }
}