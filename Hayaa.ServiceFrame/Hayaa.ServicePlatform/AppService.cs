using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Service
{
   public interface AppService
    {
        /// <summary>
        /// 检查组件是否存在
        /// </summary>
        /// <param name="appId">AppId</param>
        /// <param name="componentId">组件Id</param>
        /// <param name="appUserId">程序执行用户Id</param>
        /// <returns>存在返回true，不存在返回false</returns>
        FunctionOpenResult<bool> ExistComponent(int appId, int componentId, int appUserId);
        /// <summary>
        /// App添加组件和执行用户
        /// </summary>
        /// <param name="appId">AppId</param>
        /// <param name="componentId">组件Id</param>
        /// <param name="appUserId">程序执行用户Id</param>
        /// <returns></returns>
        FunctionOpenResult<bool> SetComponent(int appId, int componentId, int appUserId);
       
    }
}
