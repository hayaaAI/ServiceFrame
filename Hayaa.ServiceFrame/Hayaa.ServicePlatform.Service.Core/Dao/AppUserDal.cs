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
    internal partial class AppUserDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(AppUser info)
        {
            string sql = "insert into AppUser(Name,Title) values(@Name,@Title)";
            return Insert<AppUser>(con, sql, info);
        }
        internal static int Update(AppUser info)
        {
            string sql = "update AppUser set Name=@Name,Title=@Title where AppUserId=@AppUserId";
            return Update<AppUser>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  AppUser where AppUserId in @ids";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static AppUser Get(int Id)
        {
            string sql = "select * from AppUser  where AppUserId=@AppUserId";
            return Get<AppUser>(con, sql, new { AppUserId = Id });
        }
        internal static List<AppUser> GetList(AppUserSearchPamater pamater)
        {
            string sql = "select * from AppUser " + pamater.CreateWhereSql();
            return GetList<AppUser>(con, sql, pamater);
        }
        internal static GridPager<AppUser> GetGridPager(GridPagerPamater<AppUserSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from AppUser " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,*@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<AppUser>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}