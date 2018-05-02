using Hayaa.ServicePlatform.Client.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Hayaa.ServicePlatform.Client.Util;

namespace Hayaa.ServicePlatform.Client
{
    public class PlatformServiceFactory
    {
        /// <summary>
        /// 组建用户ID,【key：接口，value：接口实现类】
        /// </summary>
        private Dictionary<int, Dictionary<string, AppComponent>> _serviceData;
        private ConcurrentDictionary<string, Assembly> _assembliesData;
        private static PlatformServiceFactory _instance = new PlatformServiceFactory();

        public static PlatformServiceFactory Instance
        {
            get { return _instance; }
        }
        private PlatformServiceFactory()
        {
            _assembliesData = new ConcurrentDictionary<string, Assembly>();
            _serviceData = new Dictionary<int, Dictionary<string, AppComponent>>();
            InitData(ConfigHelper.Instance.GetComponentConfig().Components);

        }
        private void InitData(List<AppComponent> appServiceConfigs)
        {
            if (appServiceConfigs != null)
            {
                var appUserIDs = appServiceConfigs.Select(a => a.AppUserId).Distinct().ToList();
                if (appUserIDs != null)
                {
                    appUserIDs.ForEach(a =>
                    {
                        if (!_serviceData.ContainsKey(a))
                        {
                            _serviceData.Add(a, new Dictionary<string, AppComponent>());
                            var temp = appServiceConfigs.FindAll(b => b.AppUserId == a);
                            //一个实现类可能基于多个接口，此种模式对于基于一个接口实现了多个组件，并且组件用户相同情况不支持
                            temp.ForEach(c => {
                                c.ComponentInterface.ForEach(ci => {
                                    _serviceData[a].Add(ci, c);
                                });
                            });
                        }
                    });
                }
            }
        }
        public void Clear()
        {
            _serviceData.Clear();
            _assembliesData.Clear();
            ServiceFactory.Instance.Clear();
        }

        /// <summary>
        /// 创建服务实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appUserID">程序用户ID</param>
        /// <returns></returns>
        public T CreateService<T>(int appUserID)
        {
            T tobj = default(T);
            tobj = ServiceFactory.Instance.GetService<T>(appUserID);
            if (tobj != null) return tobj;
            var key = typeof(T).FullName;
            if (_serviceData.Count == 0)
            {
                InitData(ConfigHelper.Instance.GetComponentConfig().Components);
            }
            if (_serviceData[appUserID].ContainsKey(key))
            {
                var serviceData = _serviceData[appUserID][key];
                string classkey = string.Format("{0}_{1}", appUserID, serviceData.ComponentServiceCompeleteName);             
                if (!_assembliesData.ContainsKey(classkey))
                {
                    if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    {                       
                        if (!serviceData.ComponentAssemblyFileStorePath.EndsWith(@"\")) serviceData.ComponentAssemblyFileStorePath = serviceData.ComponentAssemblyFileStorePath + "\\";
                        _assembliesData.TryAdd(classkey, Assembly.LoadFrom(serviceData.ComponentAssemblyFileStorePath + serviceData.ComponentAssemblyFileName));
                    }
                }
                if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    tobj = ServiceFactory.Instance.GetService<T>(appUserID, serviceData.ComponentServiceName, _assembliesData[classkey]);
                else
                    tobj = ServiceFactory.Instance.GetService<T>(appUserID, serviceData.ComponentServiceCompeleteName);
            }
            return tobj;
        }
        /// <summary>
        /// dll程序集测试
        /// </summary>
        /// <param name="appUserID"></param>
        /// <param name="interfaceName"></param>
        /// <returns></returns>
        internal Object CreateServiceForTest(int appUserID, string interfaceName)
        {
            Object tobj = null;
            tobj = ServiceFactory.Instance.GetServiceForTest(appUserID, interfaceName);
            if (tobj != null) return tobj;
            var key = interfaceName;
            if (_serviceData.Count == 0)
            {
                InitData(ConfigHelper.Instance.GetComponentConfig().Components);
            }
            if (_serviceData[appUserID].ContainsKey(key))
            {
                var serviceData = _serviceData[appUserID][key];
                string classkey = string.Format("{0}_{1}", appUserID, serviceData.ComponentServiceCompeleteName);
                if (!_assembliesData.ContainsKey(classkey))
                {
                    if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    {                        
                        if (!serviceData.ComponentAssemblyFileStorePath.EndsWith(@"\")) serviceData.ComponentAssemblyFileStorePath = serviceData.ComponentAssemblyFileStorePath + "\\";
                        _assembliesData.TryAdd(classkey, Assembly.LoadFrom(serviceData.ComponentAssemblyFileStorePath + serviceData.ComponentAssemblyFileName));
                    }
                }
                if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    tobj = ServiceFactory.Instance.GetServiceForTest(appUserID, serviceData.ComponentServiceName, _assembliesData[classkey], interfaceName);
                else
                    tobj = ServiceFactory.Instance.GetServiceForTest(appUserID, serviceData.ComponentServiceCompeleteName, interfaceName);
            }
            return tobj;
        }
    }
}
