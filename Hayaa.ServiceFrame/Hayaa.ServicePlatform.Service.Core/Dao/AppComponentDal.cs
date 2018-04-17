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
    internal partial class AppComponentDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(AppComponent info)
        {
            string sql = "insert into AppComponent(ComponetId,ComponentServiceCompeleteName,ComponentServiceName,ComponentAssemblyName,ComponentAssemblyFileName,ComponentAssemblyFileStorePath,AssemblyVersion) values(@ComponetId,@ComponentServiceCompeleteName,@ComponentServiceName,@ComponentAssemblyName,@ComponentAssemblyFileName,@ComponentAssemblyFileStorePath,@AssemblyVersion)";
            return Insert<AppComponent>(con, sql, info);
        }
        internal static int Update(AppComponent info)
        {
            string sql = "update AppComponent set ComponetId=@ComponetId,ComponentServiceCompeleteName=@ComponentServiceCompeleteName,ComponentServiceName=@ComponentServiceName,ComponentAssemblyName=@ComponentAssemblyName,ComponentAssemblyFileName=@ComponentAssemblyFileName,ComponentAssemblyFileStorePath=@ComponentAssemblyFileStorePath,AssemblyVersion=@AssemblyVersion where AppComponentId=@AppComponentId";
            return Update<AppComponent>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  AppComponent where AppComponentId in @ids";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static AppComponent Get(int Id)
        {
            string sql = "select * from AppComponent  where AppComponentId=@AppComponentId";
            return Get<AppComponent>(con, sql, new { AppComponentId = Id });
        }
        internal static List<AppComponent> GetList(AppComponentSearchPamater pamater)
        {
            string sql = "select * from AppComponent " + pamater.CreateWhereSql();
            return GetList<AppComponent>(con, sql, pamater);
        }
        internal static GridPager<AppComponent> GetGridPager(GridPagerPamater<AppComponentSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from AppComponent " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,*@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<AppComponent>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}