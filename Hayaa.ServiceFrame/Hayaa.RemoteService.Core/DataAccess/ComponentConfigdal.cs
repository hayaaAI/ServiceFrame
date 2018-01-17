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
            string sql = "insert ComponentConfig (ComponentConfigID,ComponentConfigTitle,Name,ComponentID,Content,Version,IsDefault) values(@ComponentConfigID,@ComponentConfigTitle,@Name,@ComponentID,@Content,@Version,@IsDefault)";
            return Update<ComponentConfig>(g_con,sql, info) ;
        }

      

        internal static int update(ComponentConfig info)
        {
            string sql = "update ComponentConfig set ComponentConfigID=@ComponentConfigID,ComponentConfigTitle=@ComponentConfigTitle,Name=@Name,ComponentID=@ComponentID,Content=@Content,Version=@Version,IsDefault=@IsDefault where ID=@ID";
            return Update<ComponentConfig>(g_con,sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from ComponentConfig where ID in(@ids)";
            return Excute(g_con,sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static ComponentConfig Get(int infoID)
        {
            string sql = "select * from ComponentConfig  where ID=@ID";
            return Get<ComponentConfig>(g_con,sql, new{ ComponentConfigID=infoID}) ;
        }
		internal static List<ComponentConfig> GetList()
        {
            string sql = "select * from ComponentConfig";
            return GetList<ComponentConfig>(g_con,sql, null) ;
        }
        internal static List<ComponentConfig> GetList(int appConfigID, int version)
        {
            string sql = "select a.* from ComponentConfig a inner join Rel_AppConfig_ComponentConfig b on a.ComponentConfigID=b.ComponentConfigID and a.Version=b.ComponentConfigVersion and b.AppConfigID=@AppConfigID and b.AppConfigVersion=@AppConfigVersion and b.IsActive=1";
            return GetList<ComponentConfig>(g_con, sql, new { AppConfigID = appConfigID, AppConfigVersion=version });
        }
        internal static GridPager<ComponentConfig> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from ComponentConfig where Title like '%'+@searchKey+'%' limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<ComponentConfig>(g_con,sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
