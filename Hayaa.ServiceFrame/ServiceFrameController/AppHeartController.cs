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
    public class AppHeartController : Controller
    {
      /// <summary>
      /// 心跳服务
      /// 发送数据变更通知
      /// </summary>
      /// <param name="appid"></param>
      /// <returns></returns>
        [HttpPost("{appid?}")]
        public TransactionResult<List<int>> HeartAction(int appid)
        {
            TransactionResult<List<int>> result = new TransactionResult<List<int>>();
            //1更新配置
            //2更新权限数据
            //var serviceResult = service.Create(new AppInstance() { AppId = appid });
            //if (serviceResult.ActionResult & serviceResult.HavingData)
            //{
            //    result.Data = serviceResult.Data.AppInstanceId;
            //}
            return result;
        }
    }
}
