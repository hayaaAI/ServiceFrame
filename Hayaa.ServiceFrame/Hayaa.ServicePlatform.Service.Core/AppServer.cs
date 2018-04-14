using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Dao;

namespace Hayaa.ServicePlatform.Service.Core
{
    public class AppServer : AppService
    {
        public FunctionOpenResult<bool> AddComponent(int appId, int appComponentId, int appUserId)
        {
            FunctionOpenResult<bool> r = new FunctionOpenResult<bool>();
           r.Data= Rel_AppComponent_AppUserDal.Add(new Rel_AppComponent_AppUser() {
                 AppComponentId=appComponentId,
                  AppUserId=appUserId,
                    AppId=appId
            })>0;
            return r;
        }

        public FunctionOpenResult<bool> ExistComponent(int appId, int appComponentId, int appUserId)
        {
            FunctionOpenResult<bool> r = new FunctionOpenResult<bool>();
            var info = Rel_AppComponent_AppUserDal.Get(appId, appComponentId, appUserId);
            r.Data = (info != null);
            return r;
        }

        public FunctionOpenResult<bool> RemoveComponent(int Id)
        {
            FunctionOpenResult<bool> r = new FunctionOpenResult<bool>();
            r.Data = Rel_AppComponent_AppUserDal.Delete(new List<int>() { Id });
            return r;
        }
    }
}
