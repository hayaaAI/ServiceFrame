using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Client.Model
{
    [Serializable]
    internal class AppFunction
    {
        public int AppFuntionId { set; get; }
        public String FunctionName { set; get; }
        public String PathName { set; get; }
        public String Title { set; get; }
        public byte Status { set; get; }
        public int AppServiceId { set; get; }
    }
}
