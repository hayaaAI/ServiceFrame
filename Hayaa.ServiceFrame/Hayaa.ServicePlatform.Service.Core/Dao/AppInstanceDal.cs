using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Config;
using Hayaa.ServicePlatform.Service.Model;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service.Dao
{
    internal partial class AppInstanceDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(AppInstance info)
        {
            string sql = "insert into AppInstance(Title) values(@Title)";
            return Insert<AppInstance>(con, sql, info);
        }
        internal static int Update(AppInstance info)
        {
            string sql = "update AppInstance set Title=@Title where AppInstanceId=@AppInstanceId";
            return Insert<AppInstance>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  AppInstance where AppInstanceId in @ids";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static AppInstance Get(int Id)
        {
            string sql = "select * from AppInstance  where AppInstanceId=@AppInstanceId";
            return Get<AppInstance>(con, sql, new { AppInstanceId = Id });
        }
        internal static List<AppInstance> GetList(AppInstanceSearchPamater pamater)
        {
            string sql = "select * from AppInstance " + pamater.CreateWhereSql();
            return GetList<AppInstance>(con, sql, pamater);
        }
        internal static GridPager<AppInstance> GetGridPager(GridPagerPamater<AppInstanceSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from AppInstance " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,*@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<AppInstance>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}