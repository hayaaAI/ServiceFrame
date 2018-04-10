using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Config;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service.Dao
{
    internal partial class Rel_AppComponent_AppUserDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(Rel_AppComponent_AppUser info)
        {
            string sql = "insert into Rel_AppComponent_AppUser(Id,AppUserId,AppComponentId) values(@Id,@AppUserId,@AppComponentId)";
            return Insert<Rel_AppComponent_AppUser>(con, sql, info);
        }
        internal static int Update(Rel_AppComponent_AppUser info)
        {
            string sql = "update Rel_AppComponent_AppUser set Id=@Id,AppUserId=@AppUserId,AppComponentId=@AppComponentId where Rel_AppComponent_AppUserId=@Rel_AppComponent_AppUserId";
            return Insert<Rel_AppComponent_AppUser>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  Rel_AppComponent_AppUser where Rel_AppComponent_AppUserId in @ids";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static Rel_AppComponent_AppUser Get(int Id)
        {
            string sql = "select * from Rel_AppComponent_AppUser  where Rel_AppComponent_AppUserId=@Rel_AppComponent_AppUserId";
            return Get<Rel_AppComponent_AppUser>(con, sql, new { Rel_AppComponent_AppUserId = Id });
        }
       
    }
}