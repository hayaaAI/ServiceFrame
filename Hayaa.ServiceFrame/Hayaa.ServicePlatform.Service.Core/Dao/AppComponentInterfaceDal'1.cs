using System;
using System.Collections.Generic;


namespace Hayaa.ServicePlatform.Service.Dao
{
    internal partial class AppComponentInterfaceDal 
    {
       
        internal static bool DeleteByAppComponentId(int appComponentId)
        {
            string sql = "delete from  AppComponentInterface where AppComponentId=@AppComponentId";
            return Excute(con, sql, new { AppComponentId = appComponentId }) > 0;
        }
        internal static List<AppComponentInterface> GetListByAppComponentId(int appComponentId)
        {
            string sql = "select * from AppComponentInterface where AppComponentId=@AppComponentId";
            return GetList<AppComponentInterface>(con, sql, new { AppComponentId = appComponentId });
        }
        internal static List<AppComponentInterface> GetListByAppComponentIds(List<int> appComponentId)
        {
            string sql = "select * from AppComponentInterface where AppComponentId in @AppComponentId";
            return GetList<AppComponentInterface>(con, sql, new { AppComponentId = appComponentId });
        }
    }
}