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
    public partial class AppComponentServer : AppComponentService
    {
        public FunctionResult<AppComponent> Create(AppComponent info)
        {
            var r = new FunctionResult<AppComponent>();
            int id = AppComponentDal.Add(info);
            if (id > 0) { r.Data = info; r.Data.AppComponentId = id;
              
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(AppComponent info) { var r = new FunctionOpenResult<bool>(); r.Data = AppComponentDal.Update(info) > 0; return r; }
       
       
        public FunctionListResult<AppComponent> GetList(AppComponentSearchPamater pamater) { var r = new FunctionListResult<AppComponent>(); r.Data = AppComponentDal.GetList(pamater); return r; }
        public GridPager<AppComponent> GetPager(GridPagerPamater<AppComponentSearchPamater> searchParam) { var r = AppComponentDal.GetGridPager(searchParam); return r; }

      

        public FunctionResult<AppComponent> Get(int Id)
        {
            var r = new FunctionResult<AppComponent>();
            r.Data = AppComponentDal.Get(Id);           
            return r;
        }

      
    }
}