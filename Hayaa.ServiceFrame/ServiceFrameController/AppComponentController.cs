using Hayaa.BaseModel;
using Hayaa.BaseModel.Model;
using Hayaa.ServicePlatform.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServiceFrameController
{
    [Route("api/[controller]/[action]")]
    public partial class AppComponentController : Controller
    {
        private AppComponentService service = new AppComponentServer(); //PlatformServiceFactory.Instance.CreateService<AppComponentService>(AppRoot.GetDefaultAppUser());
        [HttpGet]
        [EnableCors("any")]
        public TransactionResult<String> test()
        {
            TransactionResult<String> result = new TransactionResult<String>();
            result.Data = "test";
            return result;
        }
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
        public TransactionResult<AppComponent> GetAppComponent(int id)
        {
            TransactionResult<AppComponent> result = new TransactionResult<AppComponent>();
            var serviceResult = service.Get(id);
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
        public TransactionResult<AppComponent> AddAppComponent(AppComponent info)
        {
            TransactionResult<AppComponent> result = new TransactionResult<AppComponent>();

            var serviceResult = service.Create(info);

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
        public TransactionResult<Boolean> EditAppComponent(AppComponent info)
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
