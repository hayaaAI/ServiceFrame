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
    public partial class AppUserServer : AppUserService
    {
        public FunctionResult<AppUser> Create(AppUser info)
        {
            var r = new FunctionResult<AppUser>(); int id = AppUserDal.Add(info); if (id > 0) { r.Data = info; r.Data.AppUserId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(AppUser info) { var r = new FunctionOpenResult<bool>(); r.Data = AppUserDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) { var r = new FunctionOpenResult<bool>(); r.Data = AppUserDal.Delete(idList); return r; }
        public FunctionResult<AppUser> Get(int Id) { var r = new FunctionResult<AppUser>(); r.Data = AppUserDal.Get(Id); return r; }
        public FunctionListResult<AppUser> GetList(AppUserSearchPamater pamater) { var r = new FunctionListResult<AppUser>(); r.Data = AppUserDal.GetList(pamater); return r; }
        public GridPager<AppUser> GetPager(GridPagerPamater<AppUserSearchPamater> searchParam) { var r = AppUserDal.GetGridPager(searchParam); return r; }

       
    }
}