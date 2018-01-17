using Hayaa.BaseModel;
using Hayaa.DataAccess;
using Hayaa.RemoteService.Core.Config;
using System;
using System.Collections.Generic;
using System.Text;


namespace Hayaa.RemoteService.DataAccess
{
    class AppConfigDal: CommonDal
    {      
	    private static string  g_con= ConfigHelper.Instance.GetConnection(DefineTable.RemoteDatabaseName);
        internal static int Add(AppConfig info)
        {
            string sql = "insert AppConfig (AppConfigID,AppID,SolutionID,SolutionName,Version,ConfigContent) values(@AppConfigID,@AppID,@SolutionID,@SolutionName,@Version,@ConfigContent)";
            return Update<AppConfig>(g_con,sql, info) ;
        }
		  internal static int update(AppConfig info)
        {
            string sql = "update AppConfig set AppConfigID=@AppConfigID,AppID=@AppID,SolutionID=@SolutionID,SolutionName=@SolutionName,Version=@Version,ConfigContent=@ConfigContent where AppConfigID=@AppConfigID";
            return Update<AppConfig>(g_con,sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from AppConfig where AppConfigID in(@ids)";
            return Excute(AppConfigDal.g_con,sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static AppConfig Get(Guid solutionID,int version)
        {
            string sql = "select * from AppConfig  where SolutionID=@SolutionID and Version=@Version";
            return Get<AppConfig>(AppConfigDal.g_con,sql, new{ SolutionID = solutionID, Version= version }) ;
        }
        internal static AppConfig Get(int infoID)
        {
            string sql = "select * from AppConfig  where AppConfigID=@AppConfigID";
            return Get<AppConfig>(AppConfigDal.g_con, sql, new { AppConfigID = infoID });
        }
        internal static List<AppConfig> GetList()
        {
            string sql = "select * from AppConfig";
            return GetList<AppConfig>(g_con,sql, null) ;
        }
		internal static GridPager<AppConfig> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from AppConfig where Title like '%'+@searchKey+'%' limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<AppConfig>(AppConfigDal.g_con,sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
