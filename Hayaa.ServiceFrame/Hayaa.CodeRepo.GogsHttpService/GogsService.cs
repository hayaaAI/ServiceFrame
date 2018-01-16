using Hayaa.BaseModel;
using System;

namespace Hayaa.CodeRepo.GogsHttpService
{
    public interface GogsService
    {
        FunctionOpenResult<String> CreateGitRepo();
    }
}
