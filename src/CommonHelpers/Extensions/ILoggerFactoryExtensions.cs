using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Logging
{
    /// <summary>
    /// 日志工厂扩展类
    /// </summary>
    public static class ILoggerFactoryExtensions
    {
        /// <summary>
        /// 添加文件日志服务-使用常用配置
        /// </summary>
        public static ILoggerFactory AddFileUseCommonConfig(this ILoggerFactory loggerFactory)
        {
            var levelOverrides = new Dictionary<string, LogLevel>();
            levelOverrides.Add("INF", LogLevel.Information);
            levelOverrides.Add("WARN", LogLevel.Warning);
            levelOverrides.Add("ERR", LogLevel.Error);
            levelOverrides.Add("CRI", LogLevel.Critical);
            levelOverrides.Add("NONE", LogLevel.None);

            return loggerFactory.AddFile("logs/log-{Date}.txt", LogLevel.Information, levelOverrides);
        }
    }
}
