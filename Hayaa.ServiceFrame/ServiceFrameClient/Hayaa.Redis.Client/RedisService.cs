using Hayaa.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.Redis.Client
{
   public class RedisService
    {
        public static void Set<T>(String name, String key, T data)
        {
            var redis = RedisFactory.GetService(name);
            if (redis != null)
            {
                redis.StringSet(key, JsonHelper.Serlaize<T>(data));
            }
        }
       
        public static T Get<T>(String name, String key)
        {
            T data = default(T);
            var redis = RedisFactory.GetService(name);
            if (redis != null)
            {
              String redisResult=  redis.StringGet(key);
                if (!String.IsNullOrEmpty(redisResult))
                {
                    data = JsonHelper.Deserialize<T>(redisResult);
                }
            }
            return data;
        }
      

        public static void Set<T>(String name, String key, T data,int cacheSeconds)
        {
            var redis = RedisFactory.GetService(name);
            if (redis != null)
            {
                redis.StringSet(key, JsonHelper.Serlaize<T>(data),new TimeSpan(0,0, cacheSeconds));
            }
        }
        public static void Delete(String name, String key)
        {
          
            var redis = RedisFactory.GetService(name);
            if (redis != null)
            {
                redis.KeyDelete(key);
            }
        }
    }
}
