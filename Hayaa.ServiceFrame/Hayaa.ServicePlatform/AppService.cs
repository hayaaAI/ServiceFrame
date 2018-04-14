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
        /// <param name="appId"></param>
        /// <param name="appComponentId"></param>
        /// <param name="appUserId"></param>
        /// <returns>存在返回true，不存在返回false</returns>
        FunctionOpenResult<bool> ExistComponent(int appId, int appComponentId, int appUserId);
        /// <summary>
        /// App添加组件和执行用户
        /// </summary>
        /// <param name="appId">AppId</param>
        /// <param name="appComponentId">组件Id</param>
        /// <param name="appUserId">程序执行用户Id</param>
        /// <returns></returns>
        FunctionOpenResult<bool> AddComponent(int appId, int appComponentId, int appUserId);
        /// <summary>
        /// App移除组件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FunctionOpenResult<bool> RemoveComponent(int Id);
    }
}
