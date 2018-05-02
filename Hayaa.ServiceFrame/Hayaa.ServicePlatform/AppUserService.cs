using Hayaa.BaseModel;
using Hayaa.BaseModel.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Service
{
  public  interface AppUserService : IBaseService<AppUser, AppUserSearchPamater>
    {
        /// <summary>
        /// 获取App下App执行用户列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        FunctionListResult<AppUser> GetList(int appId, string name);
    }
}
