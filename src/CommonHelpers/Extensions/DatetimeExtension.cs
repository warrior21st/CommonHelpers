using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 日期时间扩展类
    /// </summary>
    public static class DatetimeExtension
    {
        /// <summary>
        /// 是否是有效的时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsValid(this DateTime dt)
        {
            return dt != null && dt != default(DateTime);
        }

        /// <summary>
        /// 转换为标准格式字符串(北京时间)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isUtc"></param>
        /// <returns></returns>
        public static string ToDatetimeString(this DateTime dt, bool isUtcTime = true)
        {
            if (isUtcTime)
                dt = dt.GetBeijingTimeByUtcTime();

            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 日期时间转日期字符串(北京时间)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isUtcTime"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dt, bool isUtcTime = true)
        {
            string result = string.Empty;
            if (dt != default(DateTime))
            {
                if (isUtcTime)
                    dt = dt.GetBeijingTimeByUtcTime();
                result = dt.ToString("yyyy-MM-dd");
            }

            return result;
        }

        /// <summary>
        /// 日期转中文字符串(北京时间)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isUtcTime"></param>
        /// <returns></returns>
        public static string ToChineseString(this DateTime dt, bool isUtcTime = true)
        {
            string result = string.Empty;
            if (dt != default(DateTime))
            {
                string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                if (isUtcTime)
                    dt = dt.GetBeijingTimeByUtcTime();
                string week = weekdays[Convert.ToInt32(dt.DayOfWeek)];
                result = dt.ToString("yyyy年MM月dd日 HH时mm分");
                var arr = result.Split(' ');
                result = $"{arr[0]}({week}) {arr[1]}";
            }

            return result;
        }

        /// <summary>
        /// utc转北京时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime GetBeijingTimeByUtcTime(this DateTime dt)
        {
            return dt.AddHours(8);
        }

        /// <summary>
        /// 获取几天前
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isUtc"></param>
        /// <returns></returns>
        public static string TimeAgo(this DateTime dt, bool isUtc = true)
        {
            var now = isUtc ? DateTime.UtcNow : DateTime.Now;
            TimeSpan span = DateTime.UtcNow - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return $"{years}年前";
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return $"{months}月前";
            }
            if (span.Days > 0)
                return $"{span.Days }天前";
            if (span.Hours > 0)
                return $"{span.Hours}小时前";
            if (span.Minutes > 0)
                return $"{span.Minutes}分钟前";
            if (span.Seconds > 5)
                return $"{span.Seconds}秒前";
            if (span.Seconds <= 5)
                return "刚刚";
            return string.Empty;
        }

        /// <summary>
        /// 获取次日0点的日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime GetNextDayStart(this DateTime dt)
        {
            string dtstr = dt.AddDays(1).ToString("yyyy-MM-dd");
            dtstr += " 00:00:00.000";
            return DateTime.Parse(dtstr);
        }
    }
}
