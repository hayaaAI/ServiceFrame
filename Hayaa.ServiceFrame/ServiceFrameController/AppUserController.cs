using Hayaa.BaseModel;
using Hayaa.BaseModel.Model;
using Hayaa.ServicePlatform.Client;
using Hayaa.ServicePlatform.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServiceFrameController
{
    [Route("api/[controller]/[action]")]
    public  class AppUserController: Controller
    {
        private AppUserService service =PlatformServiceFactory.Instance.CreateService<AppUserService>(AppRoot.GetDefaultAppUser());

        [HttpPost]
        [EnableCors("any")]
        public TransactionResult<GridPager<AppUser>> GetAppUserPager(int page, int size)
        {
            TransactionResult<GridPager<AppUser>> result = new TransactionResult<GridPager<AppUser>>();
            var serviceResult = service.GetPager(new BaseModel.GridPagerPamater<AppUserSearchPamater>()
            {
                Current = page,
                PageSize = size,
                SearchPamater = new AppUserSearchPamater()
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
        public TransactionResult<AppUser> GetAppUser(int id)
        {
            TransactionResult<AppUser> result = new TransactionResult<AppUser>();
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
        public TransactionResult<AppUser> AddAppUser(AppUser info)
        {
            TransactionResult<AppUser> result = new TransactionResult<AppUser>();
           
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
        public TransactionResult<Boolean> EditAppUser(AppUser info)
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
        public TransactionResult<Boolean> DeleteAppUser(int id)
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
