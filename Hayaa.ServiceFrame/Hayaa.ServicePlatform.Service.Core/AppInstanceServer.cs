using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.ServicePlatform.Service.Dao;
using Hayaa.ServicePlatform.Service.Config;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service
{
    public partial class AppInstanceServer : AppInstanceService
    {
        public FunctionResult<AppInstance> Create(AppInstance info)
        {
            var r = new FunctionResult<AppInstance>(); int id = AppInstanceDal.Add(info); if (id > 0) { r.Data = info; r.Data.AppInstanceId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(AppInstance info) { var r = new FunctionOpenResult<bool>(); r.Data = AppInstanceDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) { var r = new FunctionOpenResult<bool>(); r.Data = AppInstanceDal.Delete(idList); return r; }
        public FunctionResult<AppInstance> Get(int Id) { var r = new FunctionResult<AppInstance>(); r.Data = AppInstanceDal.Get(Id); return r; }
        public FunctionListResult<AppInstance> GetList(AppInstanceSearchPamater pamater) { var r = new FunctionListResult<AppInstance>(); r.Data = AppInstanceDal.GetList(pamater); return r; }
        public GridPager<AppInstance> GetPager(GridPagerPamater<AppInstanceSearchPamater> searchParam) { var r = AppInstanceDal.GetGridPager(searchParam); return r; }
    }
}