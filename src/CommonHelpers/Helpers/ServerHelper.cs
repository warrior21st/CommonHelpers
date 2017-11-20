using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonHelpers.Helpers
{
    /// <summary>
    /// 服务器帮助类
    /// </summary>
    public static class ServerHelper
    {
        /// <summary>
        /// 获取程序根目录
        /// </summary>
        /// <returns></returns>
        public static string GetRootDirectory()
        {
            //typeof(ServerUtil).GetTypeInfo().Assembly.Location;

#if DEBUG
            var root = Directory.GetCurrentDirectory();
#else
            var root = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
#endif

            //root = "/root/wwwroot/zkor2.0/";
            return root;
        }

        /// <summary>
        /// 根据相对路径获取绝对路径
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string MapPath(string uri)
        {
            var path = GetRootDirectory();
            string[] arr = uri.Split('/');
            foreach (var s in arr)
            {
                if (!string.IsNullOrWhiteSpace(s))
                    path = Path.Combine(path, s);
            }

            return path;
        }
    }
}
