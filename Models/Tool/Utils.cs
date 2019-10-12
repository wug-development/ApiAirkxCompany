using Newtonsoft.Json;
using System;
using System.Data;
using System.Text;
using System.Net.Http;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace ApiAirkxCompany
{
    public class Utils
    {
        #region json 返回值格式化
        public static HttpResponseMessage pubResult(int status)
        {
            string msg = "success";
            if (status == 0)
            {
                msg = "error";
            }
            var result = new
            {
                status = status,
                msg = msg,
                data = ""
            };
            string str = JsonConvert.SerializeObject(result);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
        }

        public static HttpResponseMessage pubResult(int status, string msg, DataTable res)
        {
            var result = new
            {
                status = status,
                msg = msg,
                data = res
            };
            string str = JsonConvert.SerializeObject(result);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
        }

        public static HttpResponseMessage pubResult(int status, string msg, string res)
        {
            var result = new
            {
                status = status,
                msg = msg,
                data = res
            };
            string str = JsonConvert.SerializeObject(result, Formatting.None);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
        }


        public static HttpResponseMessage pubResult(int status, string msg, object data)
        {
            var result = new
            {
                status = status,
                msg = msg,
                data = data
            };
            string str = JsonConvert.SerializeObject(result);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
        }
        #endregion

        #region 获取数据表ID
        /// <summary>
        /// 获取数据表ID
        /// </summary>
        /// <param name="IDPrefix">ID前缀</param>
        /// <returns></returns>
        public static string getDataID(string IDPrefix)
        {
            Random rd = new Random();
            return IDPrefix + BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(DateTime.Now.ToString("yyyyMMddhhmmss")))).Replace("-", "").ToLower() + rd.Next(100, 999).ToString();
        }
        #endregion

        #region 网易发送邮件方法
        /// <summary>
        /// 发送邮件方法
        /// </summary>
        /// <param name="FromMial">发件人邮箱</param>
        /// <param name="ToMial">收件人邮箱(多个收件人地址用";"号隔开)</param>
        /// <param name="AuthorizationCode">发件人授权码</param>
        /// <param name="ReplyTo">对方回复邮件时默认的接收地址（不设置也是可以的）</param>
        /// <param name="CCMial">//邮件的抄送者(多个抄送人用";"号隔开)</param>
        /// <param name="File_Path">附件的地址</param>
        /// <returns>1成功  0失败</returns>
        public static int SendMail(string ToMial, string emailbody, string ReplyTo, string CCMial, string File_Path)
        {
            try
            {
                //实例化一个发送邮件类。
                MailMessage mailMessage = new MailMessage();

                //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
                mailMessage.Priority = MailPriority.Normal;

                //发件人邮箱地址。
                string FromMial = "13701381359@163.com";
                mailMessage.From = new MailAddress(FromMial);

                //收件人邮箱地址。需要群发就写多个
                //拆分邮箱地址
                List<string> ToMiallist = ToMial.Split(';').ToList();
                for (int i = 0; i < ToMiallist.Count; i++)
                {
                    mailMessage.To.Add(new MailAddress(ToMiallist[i]));  //收件人邮箱地址。
                }

                if (ReplyTo == "" || ReplyTo == null)
                {
                    ReplyTo = FromMial;
                }

                //对方回复邮件时默认的接收地址(不设置也是可以的哟)
                // mailMessage.ReplyTo = new MailAddress(ReplyTo);

                if (CCMial != "" && CCMial != null)
                {
                    List<string> CCMiallist = ToMial.Split(';').ToList();
                    for (int i = 0; i < CCMiallist.Count; i++)
                    {
                        //邮件的抄送者，支持群发
                        mailMessage.CC.Add(new MailAddress(CCMial));
                    }
                }
                //如果你的邮件标题包含中文，这里一定要指定，否则对方收到的极有可能是乱码。
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                //邮件正文格式
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                //邮件正文是否是HTML格式
                mailMessage.IsBodyHtml = true;

                //邮件标题。
                mailMessage.Subject = "凯行网密码重置";
                //邮件内容。
                mailMessage.Body = emailbody;

                //设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中  
                if (File_Path != "" && File_Path != null)
                {
                    //将附件添加到邮件
                    mailMessage.Attachments.Add(new Attachment(File_Path));
                    //获取或设置此电子邮件的发送通知。
                    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                }

                //实例化一个SmtpClient类。
                SmtpClient client = new SmtpClient();

                #region 设置邮件服务器地址

                //在这里我使用的是163邮箱，所以是smtp.163.com，如果你使用的是qq邮箱，那么就是smtp.qq.com。
                // client.Host = "smtp.163.com";
                if (FromMial.Length != 0)
                {
                    //根据发件人的邮件地址判断发件服务器地址   默认端口一般是25
                    string[] addressor = FromMial.Trim().Split(new Char[] { '@', '.' });
                    switch (addressor[1])
                    {
                        case "163":
                            client.Host = "smtp.163.com";
                            break;
                        case "126":
                            client.Host = "smtp.126.com";
                            break;
                        case "qq":
                            client.Host = "smtp.qq.com";
                            break;
                        case "gmail":
                            client.Host = "smtp.gmail.com";
                            break;
                        case "hotmail":
                            client.Host = "smtp.live.com";//outlook邮箱
                            //client.Port = 587;
                            break;
                        case "foxmail":
                            client.Host = "smtp.foxmail.com";
                            break;
                        case "sina":
                            client.Host = "smtp.sina.com.cn";
                            break;
                        default:
                            client.Host = "smtp.exmail.qq.com";//qq企业邮箱
                            break;
                    }
                }
                #endregion

                //使用安全加密连接。
                client.EnableSsl = true;
                //不和请求一块发送。
                client.UseDefaultCredentials = false;

                //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
                client.Credentials = new NetworkCredential(FromMial, "zk721215");

                //如果发送失败，SMTP 服务器将发送 失败邮件告诉我  
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //发送
                client.Send(mailMessage);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region DataTableToJson        
        /// <summary>
        /// 将datatable转换为json  
        /// </summary>
        /// <param name="dtb">Dt</param>
        /// <returns>JSON字符串</returns>
        public static string tableToJson(DataTable dtb)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            foreach (DataRow dr in dtb.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dtb.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);

            }
            //序列化  
            var str = jss.Serialize(dic);
            return Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                dt = dt.ToLocalTime();
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }

        /// <summary>
        /// 将datarow 转换为json  
        /// </summary>
        /// <param name="rows">DataRowS</param>
        /// <param name="dtabel"></param>
        /// <returns>JSON字符串</returns>
        public static string tableToJson(EnumerableRowCollection<DataRow> rows, DataTable dtabel)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            foreach (DataRow dr in rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dtabel.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);

            }
            //序列化  
            var str = jss.Serialize(dic);
            return Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                dt = dt.ToLocalTime();
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }
        #endregion
    }
}
