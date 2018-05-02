using Hayaa.RemoteConfigClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ProjectService.Core.Config
{
    internal class ConfigHelper: ConfigTool<RemoteServiceConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.RemoteServiceComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
