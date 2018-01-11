using System;
using Hayaa.BaseModel;
using Hayaa.ServiceFrame.Model.Project;

namespace Hayaa.ProjectService.Core
{
    public class BussinessProjectServer : BussinessProjectService
    {
        public FunctionResult<Project> Create(Project info)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public GridPager<Project> GetPager(GridPagerPamater<ProjectGridSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult UpdateByID(Project info)
        {
            throw new NotImplementedException();
        }
    }
}
