using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Service
{
    /// <summary>
    /// App的组件运行用户
    /// </summary>
   public class AppUser:BaseData
    {
        public int AppUserId { set; get; }
        public String Name { set; get; }
        public String Title { set; get; }
    }
}
