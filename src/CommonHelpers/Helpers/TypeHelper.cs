using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace CommonHelpers.Helpers
{
    /// <summary>
    /// 类型帮助类
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(T value)
        {
            string result = string.Empty;

            var attr = value.GetType().GetTypeInfo().GetCustomAttribute<DescriptionAttribute>();
            if (attr != null)
                result = attr.Description;

            return result;
        }

        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T CloneObject<T>(T obj) where T : class, new()
        {
            var result = new T();
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                p.SetValue(result, p.GetValue(obj));
            }

            return result;
        }
    }
}
