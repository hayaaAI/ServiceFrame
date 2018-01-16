using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
using Hayaa.ServiceFrame.Model.Project;

namespace Hayaa.ProjectService.Core
{
    public class BussinessProjectServer : BussinessProjectService
    {
       
        public FunctionResult<Project> Create(Project info)
        {
            var r = new FunctionResult<Project>();
            int id = ProjectDal.Add(info);
            if (id > 0)
            {
                r.Data = info;
                r.Data.ProjectID = id;
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(Project info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ProjectDal.update(info) > 0;
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ProjectDal.Delete(idList);
            return r;
        }

        public GridPager<Project> GetPager(GridPagerPamater<ProjectGridSearch> searchParam)
        {
            var r = ProjectDal.GetGridPager(searchParam.PageSize, searchParam.Current, searchParam.SearchPamater.Title);
            return r;
        }
    }
}
