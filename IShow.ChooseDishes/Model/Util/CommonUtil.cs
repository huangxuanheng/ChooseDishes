using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IShow.ChooseDishes.Model.Util
{
    public static class CommonUtil
    {
        public  static bool RegexpNumber(String value)
        {
            try
            {
                string[] array = value.Split(new char[] { '-'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var element in array)
                {
                    if (element.ToCharArray()[0] >= 'A' && element.ToCharArray()[0] <= 'Z')
                    {
                        return true;
                    }
                }
            }
            catch (Exception e) 
            {
                e.ToString();
            }

            return false;
        }
        /// <summary>
        /// <para>author: huangxianheng </para>
        /// 检查输入的是否是英文字符
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool CheckedInputChar(string value){
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            char[] chs = value.ToCharArray();
            foreach (var ch in chs)
            {
                if (!((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// <para>author: huangxianheng </para>
        /// 检查输入的字符串是否是空字符串或者去掉首尾空串后是否只包含空串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            if (value.Trim().Length == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// <para>author: huangxianheng </para>
        /// 指定的时间字符串格式是否正确，如果正确，则返回true，否则返回false
        /// </summary>
        /// <param name="value">给定的时间格式如：  08：09</param>
        /// <returns></returns>
        public static bool IsCorrectFormatTime(string value)
        {
            try
            {
                Convert.ToDateTime(value);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
    }
    
}
