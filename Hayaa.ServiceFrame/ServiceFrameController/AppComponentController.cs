﻿using Hayaa.BaseModel;
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
        private AppComponentService service = PlatformServiceFactory.Instance.CreateService<AppComponentService>(AppRoot.GetDefaultAppUser());

        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<GridPager<AppComponent>> GetAppComponentPager(int page, int size)
        {
            TransactionResult<GridPager<AppComponent>> result = new TransactionResult<GridPager<AppComponent>>();
            var serviceResult = service.GetPager(new BaseModel.GridPagerPamater<AppComponentSearchPamater>()
            {
                Current = page,
                PageSize = size,
                SearchPamater = new AppComponentSearchPamater()
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
        public TransactionResult<AppComponenView> GetAppComponent(int id)
        {
            TransactionResult<AppComponenView> result = new TransactionResult<AppComponenView>();
            var serviceResult = service.Get(id);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                var componentInterfaceResult = service.GetAppComponentInterfaces(id);
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
            var serviceResult = service.Create(info, info.ComponentInterface.Split(",").ToList());

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
            var serviceResult = service.UpdateByID(info);
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
            var serviceResult = service.DeleteByID(new List<int>() { id });
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
    }
}
