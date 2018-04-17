using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Client.Model
{
    [Serializable]
   internal class AppService
    {
        public int AppServiceId { set; get; }
        public String Name { set; get; }
        public String Title { set; get; }
        public int AppId { set; get; }
        public List<AppFunction> AppFunctions { set; get; }
    }
}
