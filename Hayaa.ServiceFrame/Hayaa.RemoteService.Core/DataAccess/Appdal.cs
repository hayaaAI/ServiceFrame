using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.RemoteService.Core.Config;
using Hayaa.BaseModel;


namespace Hayaa.RemoteService.DataAccess
{
    class AppDal: CommonDal
    {      
	    private static string  g_con= ConfigHelper.Instance.GetConnection(DefineTable.RemoteDatabaseName);
        internal static int Add(App info)
        {
            string sql = "insert App (AppID,Title,Name) values(@AppID,@Title,@Name)";
            return Update<App>(g_con,sql, info) ;
        }
		  internal static int update(App info)
        {
            string sql = "update App set AppID=@AppID,Title=@Title,Name=@Name where AppID=@AppID";
            return Update<App>(g_con,sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from App where AppID in(@ids)";
            return Excute(g_con,sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static App Get(int infoID)
        {
            string sql = "select * from App  where AppID=@AppID";
            return Get<App>(g_con,sql, new{ AppID=infoID}) ;
        }
		internal static List<App> GetList()
        {
            string sql = "select * from App";
            return GetList<App>(g_con,sql, null) ;
        }
		internal static GridPager<App> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from App where Title like '%'+@searcheKey+'%' limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<App>(g_con,sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
