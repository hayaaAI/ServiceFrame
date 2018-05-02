using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hayaa.Redis.Client
{ /// <summary>
  /// 缓存读写类型
  /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// 只读缓存数据.
        /// 当缓存不存在时,可能返回null或类型的默认值
        /// </summary>
        Read = 0,
        /// <summary>
        /// 返回数据,并将数据写入缓存(不从缓存读取数据).
        /// 即,每次都会将最新数据写入到缓存
        /// </summary>
        Write = 1,
        /// <summary>
        /// 优先读取缓存数据.
        /// 当缓存不存在时,先读取后写入
        /// </summary>
        ReadWrite = 2      
    }
    [Serializable]
   public class CacheAttribute : Attribute
    {
        /// <summary>
        /// 缓存有效时长,单位：秒
        /// </summary>
        private int g_CacheSeconds = 0;
        /// <summary>
        /// 缓存主键名称
        /// </summary>
        private string g_CacheKey = "";
        private ActionType g_ActionType = ActionType.ReadWrite;
        /// <summary>
        /// 配置名
        /// </summary>
        private string g_configName = "";      
        #region 需要截获特定参数时的构造函数  
        private string[] _paramsNames;
        /// <summary>  
        ///   
        /// </summary>  
        /// <param name="paramsNames">和被标签函数的参数必须相同顺序</param>  
        public CacheAttribute(string configName, string cacheKey, int cacheSeconds=0,ActionType actionType = ActionType.ReadWrite)
        {
            g_CacheSeconds = cacheSeconds;
            g_CacheKey = cacheKey;
            g_ActionType = actionType;
            g_configName = configName;
        }
        #endregion
        /// <summary>  
        /// 入口处理  
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnEntry(PostSharp.Aspects.MethodExecutionArgs args)
        {
            //当为Write模式时,不从缓存读取数据.&& 当RemoveOnSuccess时不继续执行OnEntry
            if (g_ActionType == ActionType.Write) { return; }

            string key = GetMethodKey(args, this);
            try
            {

                object returnObj = RedisService.Get<Object>(g_configName, key);
                if (returnObj != null)
                {
                    args.ReturnValue = returnObj;
                    args.FlowBehavior = PostSharp.Aspects.FlowBehavior.Return;
                    return;
                }
            }

            catch (Exception ex)
            {
               
            }
        }
        /// <summary>  
        /// 方法执行后，置入缓存
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnSuccess(PostSharp.Aspects.MethodExecutionArgs args)
        {
            //当为Read模式时,只读取缓存数据,不进行写操作 .&& 当RemoveOnEntry操作时,删除缓存的操作只在OnEntry进行,退出OnSuccess.
            if (g_ActionType == ActionType.Read ) { return; }
            try
            {
                string key = GetMethodKey(args, this);
                if (g_CacheSeconds > 0) {
                    RedisService.Set<Object>(g_configName, key, args.ReturnValue, g_CacheSeconds);
                }
                else
                {
                    RedisService.Set<Object>(g_configName, key, args.ReturnValue);
                }
            }
            catch (Exception ex)
            {
               
            }
            base.OnSuccess(args);
        }
        /// <summary>  
        /// 发生异常时的处理  
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnException(PostSharp.Aspects.MethodExecutionArgs args)
        {
            base.OnException(args);
        }
        /// <summary>  
        /// 流程完成退出时  
        /// </summary>  
        /// <param name="args"></param>  
        public override void OnExit(PostSharp.Aspects.MethodExecutionArgs args)
        {
            base.OnExit(args);
        }
        private static string GetMethodKey(PostSharp.Aspects.MethodExecutionArgs args, CacheAttribute metadata)
        {
            string key;           
                key = metadata.g_CacheKey.Trim();
                #region 判断是否包含格式化
                var match = Regex.Matches(key, "{\\d+}", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (match.Count > 0)
                {
                    try
                    {
                        key = string.Format(key, args.Arguments.ToArray());
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }               
                #endregion
                return key;
        }
        /// <summary>  
        /// 参数截获  
        /// 此方法的逻辑决定变参构造函数和被标签函数的参数必须相同顺序  
        /// </summary>  
        /// <param name="arguments"></param>  
        private void CapturePamatersValue(PostSharp.Aspects.Arguments arguments)
        {
            if (arguments == null) return;
            if (_paramsNames == null) return;
            for (int i = 0; i < _paramsNames.Length; i++)
            {
                switch (_paramsNames[i])
                {
                    case "需要截获参数":
                        object 变量 = arguments.GetArgument(i);//截获逻辑处理  
                        break;

                    default: break;
                }
            }
        }
    }
}
