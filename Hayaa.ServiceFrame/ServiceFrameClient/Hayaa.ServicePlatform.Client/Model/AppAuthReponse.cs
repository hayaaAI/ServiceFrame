using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ServicePlatform.Client.Model
{
   internal class AppAuthReponse
    {
        /// <summary>
        /// 申请到的实例Id
        /// </summary>
        public int AppInstanceId { set; get; }
        /// <summary>
        /// 申请的实例token
        /// </summary>
        public String AppInstanceToken { set; get; }
    }
}
