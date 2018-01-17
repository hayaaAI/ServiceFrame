using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.DataAccess;
using Hayaa.ProjectService.Core.Config;
using Hayaa.ServiceFrame.Model.Project;

namespace Hayaa.ProjectService
{
    class ProjectDal: CommonDal
    {      
	    private static string  g_con= ConfigHelper.Instance.GetConnection(DefineTable.AutoAIDatabaseName);
        internal static int Add(Project info)
        {
            string sql = "insert Project (ProjectID,Title,Name,StartTime,EndTime,Status,Type) values(@ProjectID,@Title,@Name,@StartTime,@EndTime,@Status,@Type)";
            return Update<Project>(g_con,sql, info) ;
        }
		  internal static int update(Project info)
        {
            string sql = "update Project set ProjectID=@ProjectID,Title=@Title,Name=@Name,StartTime=@StartTime,EndTime=@EndTime,Status=@Status,Type=@Type where ProjectID=@ProjectID";
            return Update<Project>(g_con,sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from Project where ProjectID in(@ids)";
            return Excute(g_con,sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static Project Get(int infoID)
        {
            string sql = "select * from Project  where ProjectID=@ProjectID";
            return Get<Project>(g_con,sql, new{ ProjectID=infoID}) ;
        }
		internal static List<Project> GetList()
        {
            string sql = "select * from Project";
            return GetList<Project>(g_con,sql, null) ;
        }
		internal static GridPager<Project> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from Project where Title like '%'+@searchKey+'%' limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<Project>(g_con,sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
