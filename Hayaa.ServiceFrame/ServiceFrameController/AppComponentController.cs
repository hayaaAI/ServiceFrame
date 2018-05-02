using Hayaa.BaseModel;
using Hayaa.BaseModel.Model;
using Hayaa.ServiceFrameController.Model;
using Hayaa.ServicePlatform.Client;
using Hayaa.ServicePlatform.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayaa.ServiceFrameController
{
    [Route("api/[controller]/[action]")]
    public partial class AppComponentController : Controller
    {
        private AppComponentService appComponentService =PlatformServiceFactory.Instance.CreateService<AppComponentService>(AppRoot.GetDefaultAppUser());
        private AppService appService =PlatformServiceFactory.Instance.CreateService<AppService>(AppRoot.GetDefaultAppUser());

        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<GridPager<AppComponent>> GetAppComponentPager(int page, int size,int componentId)
        {
            TransactionResult<GridPager<AppComponent>> result = new TransactionResult<GridPager<AppComponent>>();
            var serviceResult = appComponentService.GetPager(new BaseModel.GridPagerPamater<AppComponentSearchPamater>()
            {
                Current = page,
                PageSize = size,
                SearchPamater = new AppComponentSearchPamater() {  ComponentId= componentId }
            });
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<List<AppComponenJsonView>> GetAppComponentList(int appId, int componentId)
        {
            TransactionResult<List<AppComponenJsonView>> result = new TransactionResult<List<AppComponenJsonView>>();
            var serviceResult = appComponentService.GetAppComponentListWithAppUser(appId,componentId);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                var dicResult = appComponentService.GetAppComponentInterfacesByIds(serviceResult.Data.Select(a => a.AppComponentId).ToList());
                result.Data = serviceResult.Data.Select(a=> new AppComponenJsonView() {
                    AppComponentId = a.AppComponentId,
                    AssemblyVersion = a.AssemblyVersion,
                    ComponentAssemblyFileName = a.ComponentAssemblyFileName,
                    ComponentAssemblyFileStorePath = a.ComponentAssemblyFileStorePath,
                    ComponentAssemblyName = a.ComponentAssemblyName,
                    ComponentId = a.ComponentId,
                    ComponentServiceCompeleteName = a.ComponentServiceCompeleteName,
                    ComponentServiceName = a.ComponentServiceName,
                    AppUserId =a.AppUserId,
                    ComponentInterface = dicResult.Data[a.AppComponentId],
                }).ToList();
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<AppComponenView> GetAppComponent(int id)
        {
            TransactionResult<AppComponenView> result = new TransactionResult<AppComponenView>();
            var serviceResult = appComponentService.Get(id);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                var componentInterfaceResult = appComponentService.GetAppComponentInterfaces(id);
                result.Data = new AppComponenView()
                {
                    AppComponentId = serviceResult.Data.AppComponentId,
                    AssemblyVersion = serviceResult.Data.AssemblyVersion,
                    ComponentAssemblyFileName = serviceResult.Data.ComponentAssemblyFileName,
                    ComponentAssemblyFileStorePath = serviceResult.Data.ComponentAssemblyFileStorePath,
                    ComponentAssemblyName = serviceResult.Data.ComponentAssemblyName,
                    ComponentId = serviceResult.Data.ComponentId,
                    ComponentServiceCompeleteName = serviceResult.Data.ComponentServiceCompeleteName,
                    ComponentServiceName = serviceResult.Data.ComponentServiceName,
                    AppUserId = 0,
                    ComponentInterface = String.Join(",", componentInterfaceResult.Data),

                };
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<AppComponent> AddAppComponent(AppComponenView info)
        {
            TransactionResult<AppComponent> result = new TransactionResult<AppComponent>();
            if (String.IsNullOrEmpty(info.ComponentInterface))
            {
                result.Code = 101;
                result.Message = "缺少接口参数";
                return result;
            }
            var serviceResult = appComponentService.Create(info, info.ComponentInterface.Split(",").ToList());

            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> EditAppComponent(AppComponenView info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = appComponentService.UpdateByID(info, info.ComponentInterface.Split(",").ToList());
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<Boolean> DeleteAppComponent(int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = appComponentService.DeleteByID(new List<int>() { id });
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }       
        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<List<AppComponent>> CreateFactoryConfig(int appId,int componentId,int appUserId)
        {
            TransactionResult<List<AppComponent>> result = new TransactionResult<List<AppComponent>>();
            var serviceResult = appService.SetComponent(appId, componentId, appUserId);
            if (serviceResult.ActionResult&&serviceResult.Data)
            {
              var acResult=  appComponentService.GetList(new AppComponentSearchPamater() { ComponentId = componentId });
                if (acResult.ActionResult && acResult.HavingData)
                    result.Data = acResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
    }
}
