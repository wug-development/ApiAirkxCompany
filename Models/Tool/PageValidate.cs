using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ApiAirkxCompany
{
    public class PageValidate
    {
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegNumber = new Regex("^[0-9]+$");

        public PageValidate()
        {

        }

        #region 防SQL注入
        /// <summary>
        /// 替换带有SQL注入可能的字符
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static string SQL_KILL(string psValue)
        {
            string sSqlKeyWord;//, SQL_KILL_1, SQL_KILL_2, ISTR_KILL;
            string webUrl = psValue;
            string sRen;
            //int i=0;
            sRen = psValue;
            if (sRen == null)//验证是否为空
            {
                return "";
            }
            if (sRen == "")//验证是否为空串
            {
                return "";
            }
            sSqlKeyWord = "exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare|set|from|script|var|varchar";
            string[] sSqlArrayList = sSqlKeyWord.Split('|');
            foreach (string sSqlTemp in sSqlArrayList)
            {
                sRen = sRen.ToLower().Replace(sSqlTemp, ToSBC(sSqlTemp));
            }

            if (sRen.Length >= webUrl.Length)
            {
                sRen = webUrl;
            }
            sRen = sRen.Replace("'", "");
            sRen = sRen.Replace("&NBSP;", "&nbsp;");
            return sRen;
        }
        #endregion

        #region 转全角的函数

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        #endregion

        #region MD5 加密
        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Md5(string str)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(str))).Replace("-", "").ToLower();
        }
        #endregion

        #region 中文检测
        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 数字字符串检查
        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 数字和英文
        /// <summary>
        /// 判断里面是否有指定字符串
        /// </summary>
        public static bool IsChinese(string inString)
        {
            Regex regex = new Regex("^[A-Za-z0-9]+$");
            return regex.IsMatch(inString.Trim());
        }
        #endregion

        #region 替换掉非指定类型的字符串
        /// <summary>
        /// 替换掉非指定类型的字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="types">类型 1数字和英文 2汉字</param>
        /// <returns></returns>
        public static string replayStr(string s, int types)
        {
            string text = "";
            switch (types)
            {
                case 1:
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (IsChinese(s.Substring(i, 1)))
                        {
                            text += s.Substring(i, 1);
                        }
                        else
                        {
                            text += "|";
                        }
                    }; break;
                case 2:
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (IsHasCHZN(s.Substring(i, 1)) || s.Substring(i, 1) == "*")
                        {
                            text += s.Substring(i, 1);
                        }
                        else
                        {
                            text += "|";
                        }
                    }; break;
            }
            return text;
        }
        #endregion
    }
}