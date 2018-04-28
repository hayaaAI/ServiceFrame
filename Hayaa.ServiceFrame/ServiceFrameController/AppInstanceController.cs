using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel.Model;
using Hayaa.ServicePlatform.Client;
using Hayaa.ServicePlatform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hayaa.ServiceFrameController
{
    [Route("api/[controller]/[action]")]
    public class AppInstanceController : Controller
    {
        private AppInstanceService service = PlatformServiceFactory.Instance.CreateService<AppInstanceService>(AppRoot.GetDefaultAppUser());
        [HttpPost("{appid?}")]
        public TransactionResult<int> Add(int appid)
        {
            TransactionResult<int> result = new TransactionResult<int>();
            var serviceResult = service.Create(new AppInstance() { AppId = appid });
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data.AppInstanceId;
            }
            return result;
        }
    }
}
