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
    internal partial class AppComponentInterfaceDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(AppComponentInterface info)
        {
            string sql = "insert into AppComponentInterface(Id,ComponentInterface,AppComponentId) values(@Id,@ComponentInterface,@AppComponentId)";
            return Insert<AppComponentInterface>(con, sql, info);
        }
        internal static int Update(AppComponentInterface info)
        {
            string sql = "update AppComponentInterface set Id=@Id,ComponentInterface=@ComponentInterface,AppComponentId=@AppComponentId where AppComponentInterfaceId=@AppComponentInterfaceId";
            return Insert<AppComponentInterface>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  AppComponentInterface where AppComponentInterfaceId in @ids";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static AppComponentInterface Get(int Id)
        {
            string sql = "select * from AppComponentInterface  where AppComponentInterfaceId=@AppComponentInterfaceId";
            return Get<AppComponentInterface>(con, sql, new { AppComponentInterfaceId = Id });
        }
      
    }
}