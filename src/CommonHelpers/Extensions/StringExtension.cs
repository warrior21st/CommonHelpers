using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 字符串扩展类
    /// </summary>
    public static class StringExtension
    {
        ///// <summary>
        ///// 是否为空或null
        ///// </summary>
        ///// <param name="content"></param>
        ///// <returns></returns>
        //public static bool IsNothing(this string content)
        //{
        //    return string.IsNullOrWhiteSpace(content);
        //}

        /// <summary>
        /// 过滤乱码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string FilterInvalidChar(this string content)
        {
            string result = null;
            if (!string.IsNullOrWhiteSpace(content))
            {
                content = content.Trim();
                var arr = new UnicodeCategory[] { UnicodeCategory.OtherSymbol, UnicodeCategory.Surrogate };
                foreach (var c in content)
                {
                    if (!arr.Contains(CharUnicodeInfo.GetUnicodeCategory(c)))
                        result += c;
                }
            }

            return result;
        }

        /// <summary>
        /// 忽略大小写比对2个字符串是否相等
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool CompareIgnoreCase(this string a, string b)
        {
            return a.ToLower() == b.ToLower();
        }

        /// <summary>
        /// 判断字符串是否包含数组中的任一元素
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool ContainsArray(this string sourceStr, string[] arr)
        {
            var b = false;
            if (!string.IsNullOrWhiteSpace(sourceStr) && arr != null && arr.Length > 0)
            {
                foreach (var s in arr)
                {
                    if (sourceStr.Contains(s))
                    {
                        b = true;
                        break;
                    }
                }
            }

            return b;
        }


    }
}
