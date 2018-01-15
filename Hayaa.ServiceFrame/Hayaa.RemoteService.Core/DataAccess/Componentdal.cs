using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.RemoteService.Core.Config;
using Hayaa.BaseModel;

namespace Hayaa.RemoteService.DataAccess
{
    class ComponentDal: CommonDal
    {      
	    private static string  g_con= ConfigHelper.Instance.GetConnection(DefineTable.RemoteDatabaseName);
        internal static int Add(Component info)
        {
            string sql = "insert Component (ID,ComponentID,Title,Name) values(@ID,@ComponentID,@Title,@Name)";
            return Update<Component>(g_con,sql, info) ;
        }
		  internal static int update(Component info)
        {
            string sql = "update Component set ID=@ID,ComponentID=@ComponentID,Title=@Title,Name=@Name where ComponentID=@ComponentID";
            return Update<Component>(g_con,sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from Component where AppID in(@ids)";
            return Excute(g_con,sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static Component Get(int infoID)
        {
            string sql = "select * from Component  where ComponentID=@ComponentID";
            return Get<Component>(g_con,sql, new{ ComponentID=infoID}) ;
        }
		internal static List<Component> GetList()
        {
            string sql = "select * from Component";
            return GetList<Component>(g_con,sql, null) ;
        }
		internal static GridPager<Component> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from Component where Title like '%'+@searchKey+'%' limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<Component>(g_con,sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
