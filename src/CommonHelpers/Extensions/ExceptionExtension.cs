using System;
using System.Collections.Generic;
using System.Text;

namespace CommonHelpers.Extensions
{
    /// <summary>
    /// 异常扩展类
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// 获取异常详细信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetDetailInfo(this Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("======================================================================================");
            sb.Append(Environment.NewLine);
            sb.Append("Message:");
            sb.Append(ex.Message);
            sb.Append(Environment.NewLine);
            sb.Append("Source:");
            sb.Append(ex.Source);
            sb.Append(Environment.NewLine);
            sb.Append("StackTrace:");
            sb.Append(ex.StackTrace);

            return sb.ToString();
        }
    }
}
