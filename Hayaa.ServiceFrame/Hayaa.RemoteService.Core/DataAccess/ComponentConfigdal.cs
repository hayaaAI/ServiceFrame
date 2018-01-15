using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.RemoteService.Core.Config;
using Hayaa.BaseModel;

namespace Hayaa.RemoteService.DataAccess
{
    class ComponentConfigDal: CommonDal
    {      
	    private static string  g_con= ConfigHelper.Instance.GetConnection(DefineTable.RemoteDatabaseName);
        internal static int Add(ComponentConfig info)
        {
            string sql = "insert ComponentConfig (ComponentConfigID,ComponentConfigTitle,Name,ComponentID,Content,Version,IsDefault,CreateTime) values(@ComponentConfigID,@ComponentConfigTitle,@Name,@ComponentID,@Content,@Version,@IsDefault,@CreateTime)";
            return Update<ComponentConfig>(g_con,sql, info) ;
        }
		  internal static int update(ComponentConfig info)
        {
            string sql = "update ComponentConfig set ComponentConfigID=@ComponentConfigID,ComponentConfigTitle=@ComponentConfigTitle,Name=@Name,ComponentID=@ComponentID,Content=@Content,Version=@Version,IsDefault=@IsDefault,CreateTime=@CreateTime where ComponentConfigID=@ComponentConfigID";
            return Update<ComponentConfig>(g_con,sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from ComponentConfig where AppID in(@ids)";
            return Excute(g_con,sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static ComponentConfig Get(int infoID)
        {
            string sql = "select * from ComponentConfig  where ComponentConfigID=@ComponentConfigID";
            return Get<ComponentConfig>(g_con,sql, new{ ComponentConfigID=infoID}) ;
        }
		internal static List<ComponentConfig> GetList()
        {
            string sql = "select * from ComponentConfig";
            return GetList<ComponentConfig>(g_con,sql, null) ;
        }
		internal static GridPager<ComponentConfig> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from ComponentConfig where 1=1 limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<ComponentConfig>(g_con,sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
