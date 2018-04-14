using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.ServicePlatform.Service
{
    public class Rel_AppComponent_AppUser : BaseData
    {
        public int Id { set; get; }
        public int AppId { set; get; }
        public int AppUserId { set; get; }
        public int AppComponentId { set; get; }
        public DateTime? CreateTime { set; get; }
    }
}