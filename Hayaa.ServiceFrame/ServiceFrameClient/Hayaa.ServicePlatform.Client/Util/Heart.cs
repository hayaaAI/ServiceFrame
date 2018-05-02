using Hayaa.BaseModel.Model;
using Hayaa.Common;
using Hayaa.ConfigSeed.Standard;
using Hayaa.Security.Client;
using Hayaa.ServicePlatform.Client.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Hayaa.ServicePlatform.Client.Util
{
    internal class Heart
    {
        private static Heart _isntance = new Heart();

        private Heart()
        {

        }
        internal static Heart Isntance { get => _isntance; }
        private static Timer g_timer = null;
        private void HeartAction(object state)
        {
            String response = null;
            var urlParamater = new Dictionary<string, string>();
            urlParamater.Add("t", g_token);
            urlParamater.Add("appinstanceid", g_appInstanceId.ToString());
            urlParamater.Add("appid", g_appId.ToString());
            response = HttpHelper.Transaction(ConfigHelper.Instance.GetComponentConfig().HeartServiceUrl, urlParamater);
            try
            {
                TransactionResult<List<int>> serviceResult = JsonHelper.DeserializeSafe<TransactionResult<List<int>>>(response);
                if (serviceResult.Code == 0)
                {

                    if (serviceResult.Data.Contains(1))
                    {
                        AppSeed.Instance.Resetonfig();
                    }
                    if (serviceResult.Data.Contains(2))
                    {
                        SecurityRoot.Reset(g_appId);
                    }
                }
            }
            catch
            {

            }
        }
        private String g_token;
        private int g_appInstanceId;
        private int g_appId;
        public void Start(String token, int appInstanceId, int appId)
        {
            g_token = token;
            g_appInstanceId = appInstanceId;
            g_appId = appId;
            g_timer = new Timer(HeartAction, null, ConfigHelper.Instance.GetComponentConfig().HeartTimespan * 1000, 5 * 60 * 1000);
        }
    }
}
