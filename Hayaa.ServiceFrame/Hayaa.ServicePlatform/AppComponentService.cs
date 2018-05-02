using Hayaa.BaseModel;
using Hayaa.BaseModel.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Service
{
   public interface AppComponentService : IBaseService<AppComponent, AppComponentSearchPamater>
    {
        /// <summary>
        /// 添加组件信息
        /// </summary>
        /// <param name="info">组件信息</param>
        /// <param name="interfaces">组件接口列表</param>
        /// <returns></returns>
        FunctionResult<AppComponent> Create(AppComponent info, List<String> interfaces);
        /// <summary>
        /// 更新组件信息
        /// </summary>
        /// <param name="info">组件信息</param>
        /// <param name="interfaces">组件接口列表</param>
        /// <returns></returns>
        FunctionOpenResult<bool> UpdateByID(AppComponent info, List<String> interfaces);
        /// <summary>
        /// 获取组件接口列表
        /// </summary>
        /// <param name="appComponentId">组件Id</param>
        /// <returns></returns>
        FunctionOpenResult<List<String>> GetAppComponentInterfaces(int appComponentId);
        FunctionOpenResult<Dictionary<int,List<String>>> GetAppComponentInterfacesByIds(List<int> appComponentIds);
        /// <summary>
        /// 获取App下的组件列表
        /// </summary>
        /// <param name="appId">AppId</param>
        /// <param name="name">组件名称</param>
        /// <returns></returns>
        FunctionListResult<AppComponent> GetList(int appId,String name);
        FunctionListResult<AppComponent> GetAppComponentListWithAppUser(int appId, int componentId);
    }
}
