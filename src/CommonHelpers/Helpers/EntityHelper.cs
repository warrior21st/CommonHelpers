using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace CommonHelpers.Helpers
{
    /// <summary>
    /// 实体帮助类
    /// </summary>
    public class EntityHelper
    {
        /// <summary>
        /// 是否包含属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <param name="IgnoreCase"></param>
        /// <returns></returns>
        public static bool HasProperty<T>(string property, bool IgnoreCase = false) where T : class
        {
            var result = false;
            if (!string.IsNullOrWhiteSpace(property))
            {
                var properties = GetEntityProperties<T>();
                foreach (var p in properties)
                {
                    if (p.Name == property || (IgnoreCase && p.Name.CompareIgnoreCase(property)))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取实体映射的表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetTableName<T>() where T : class
        {
            var result = string.Empty;
            var t = typeof(T);
            var obs = t.GetTypeInfo().GetCustomAttribute<TableAttribute>();
            if (obs != null)
                result = t.Name;
            else
                result = obs.Name;

            return result;
        }

        /// <summary>
        /// 获取实体属性列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PropertyInfo[] GetEntityProperties<T>() where T : class
        {
            var t = typeof(T);
            var key = $"{t.FullName}_Properties_Cache";
            if (!MemoryCacheHelper.Exists(key))
            {
                var properties = t.GetProperties();

                MemoryCacheHelper.SetCache(key, properties);
            }

            return MemoryCacheHelper.GetCache<PropertyInfo[]>(key);
        }
    }
}
