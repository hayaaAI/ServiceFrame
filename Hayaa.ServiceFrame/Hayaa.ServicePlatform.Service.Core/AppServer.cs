using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Dao;

namespace Hayaa.ServicePlatform.Service.Core
{
    public class AppServer : AppService
    {
        /// <summary>
        /// No safe TODO
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="componentId"></param>
        /// <param name="appUserId"></param>
        /// <returns></returns>
        public FunctionOpenResult<bool> SetComponent(int appId, int componentId, int appUserId)
        {
            FunctionOpenResult<bool> r = new FunctionOpenResult<bool>();
            var existResult = ExistComponent(appId, componentId, appUserId);
            if (existResult.ActionResult && existResult.Data)
            {
                Rel_AppComponent_AppUserDal.Delete(appId, componentId);
            }
            var list = AppComponentDal.GetList(new AppComponentSearchPamater() { ComponentId = componentId });
            if (list != null)
            {
                list.ForEach(c =>
                {
                    Rel_AppComponent_AppUserDal.Add(new Rel_AppComponent_AppUser()
                    {
                        AppComponentId = c.AppComponentId,
                        AppUserId = appUserId,
                        AppId = appId
                    });
                });
            }
            r.Data = true;
            return r;
        }

        public FunctionOpenResult<bool> ExistComponent(int appId, int componentId, int appUserId)
        {
            FunctionOpenResult<bool> r = new FunctionOpenResult<bool>();
            var info = Rel_AppComponent_AppUserDal.GetList(appId, componentId, appUserId);
            r.Data = (info != null);
            return r;
        }

       
    }
}
