using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Dao;
using System.Linq;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service
{
    public partial class AppComponentServer
    {
        public FunctionResult<AppComponent> Create(AppComponent info, List<String> interfaces)
        {
            var r = new FunctionResult<AppComponent>();
            int id = AppComponentDal.Add(info);
            if (id > 0)
            {
                r.Data = info; r.Data.AppComponentId = id;
                interfaces.ForEach(i =>
                {
                    AppComponentInterfaceDal.Add(new AppComponentInterface()
                    {
                        ComponentInterface = i,
                        AppComponentId = id
                    });
                });
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(AppComponent info, List<String> interfaces)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = AppComponentDal.Update(info) > 0;
            if (r.Data)
            {
                AppComponentInterfaceDal.DeleteByAppComponentId(info.AppComponentId);
                interfaces.ForEach(i =>
                {
                    AppComponentInterfaceDal.Add(new AppComponentInterface()
                    {
                        ComponentInterface = i,
                        AppComponentId = info.AppComponentId
                    });
                });
            }
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = AppComponentDal.Delete(idList);
            if (r.Data)
            {
                idList.ForEach(id =>
                {
                    AppComponentInterfaceDal.DeleteByAppComponentId(id);
                });
            }
            return r;
        }
        public FunctionOpenResult<List<string>> GetAppComponentInterfaces(int appComponentId)
        {
            var r = new FunctionOpenResult<List<string>>();

            var interfaces = AppComponentInterfaceDal.GetListByAppComponentId(appComponentId);
            if (interfaces != null)
            {
                r.Data = interfaces.Select(i => i.ComponentInterface).ToList();
            }
            return r;
        }
        public FunctionListResult<AppComponent> GetList(int appId, string name)
        {
            var r = new FunctionListResult<AppComponent>();
            r.Data = AppComponentDal.GetList(appId, name);
            return r; }
    }
}