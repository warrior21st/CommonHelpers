using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Microsoft.AspNetCore.Http
{
    /// <summary>
    /// 连接上下文扩展类
    /// </summary>
    public static class HttpContextExtension
    {
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP(this HttpContext context)
        {
            string result = GetInfoFromRequestHeader(context.Request.Headers, "X-Forwarded-For");
            if (string.IsNullOrWhiteSpace(result))
                result = context.Connection.RemoteIpAddress.ToString();

            return result;
        }

        /// <summary>
        /// 获取客户端浏览器信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetClientUserAgent(this HttpContext context)
        {
            string result = GetInfoFromRequestHeader(context.Request.Headers, "User-Agent");
            if (string.IsNullOrWhiteSpace(result))
                result = GetInfoFromRequestHeader(context.Request.Headers, "UserAgent");

            return result;
        }

        /// <summary>
        /// 获取客户端页面地址
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetClientReferer(this HttpContext context)
        {
            string result = GetInfoFromRequestHeader(context.Request.Headers, "Referer");

            return result;
        }

        /// <summary>
        /// 判断请求是否来自本站页面
        /// </summary>
        /// <param name="context"></param>
        /// <param name="siteRootUri"></param>
        /// <returns></returns>
        public static bool IsOwnSiteRequest(this HttpContext context, string siteRootUri)
        {
            bool b = false;
            string referer = GetClientReferer(context);
            if (!string.IsNullOrWhiteSpace(referer) && !string.IsNullOrWhiteSpace(siteRootUri))
            {
                var refUrl = referer;
                var uri = new Uri(referer);
                var host = uri.Host.ToLower();
                siteRootUri = siteRootUri.ToLower();
                b = host.StartsWith($"www.{siteRootUri}") || refUrl.StartsWith(siteRootUri);
            }

            return b;
        }

        /// <summary>
        /// 从请求头里获取信息
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetInfoFromRequestHeader(IHeaderDictionary headers, string key)
        {
            string result = null;
            if (!string.IsNullOrWhiteSpace(headers[key].FirstOrDefault()))
                result = headers[key].FirstOrDefault();

            return result;
        }
    }
}
