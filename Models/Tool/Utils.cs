﻿using Newtonsoft.Json;
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
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

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
                //发件人邮箱地址。
                string FromMial = "kaixing_service@163.com"; ///   "kaixing_service@163.com"  "wuguang407906079@163.com"
                string FromPass = "LHUKAXARGFBBSLPM"; /// 授权码   "LHUKAXARGFBBSLPM"    "XPHVMFGAGWOXFMTH"

                //string FromMial = "wuguang407906079@163.com"; ///
                //string FromPass = "XPHVMFGAGWOXFMTH"; /// 授权码   

                //实例化一个发送邮件类。
                MailMessage mailMessage = new MailMessage();

                //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
                mailMessage.Priority = MailPriority.High;

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
                    List<string> CCMiallist = CCMial.Split(';').ToList();
                    for (int i = 0; i < CCMiallist.Count; i++)
                    {
                        //邮件的抄送者，支持群发
                        mailMessage.CC.Add(new MailAddress(CCMial));
                    }
                }
                //邮件标题。
                mailMessage.Subject = "凯行网密码重置";
                //如果你的邮件标题包含中文，这里一定要指定，否则对方收到的极有可能是乱码。
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                //邮件正文格式
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                //邮件正文是否是HTML格式
                //mailMessage.IsBodyHtml = true;
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
                client.Host = "smtp.163.com";

                //if (FromMial.Length != 0)
                //{
                //    //根据发件人的邮件地址判断发件服务器地址   默认端口一般是25
                //    string[] addressor = FromMial.Trim().Split(new Char[] { '@', '.' });
                //    switch (addressor[1])
                //    {
                //        case "163":
                //            client.Host = "smtp.163.com";
                //            break;
                //        case "126":
                //            client.Host = "smtp.126.com";
                //            break;
                //        case "qq":
                //            client.Host = "smtp.qq.com";
                //            break;
                //        case "gmail":
                //            client.Host = "smtp.gmail.com";
                //            break;
                //        case "hotmail":
                //            client.Host = "smtp.live.com";//outlook邮箱
                //            //client.Port = 587;
                //            break;
                //        case "foxmail":
                //            client.Host = "smtp.foxmail.com";
                //            break;
                //        case "sina":
                //            client.Host = "smtp.sina.com.cn";
                //            break;
                //        case "airkx":
                //            client.Host = "smtp.airkx.com";
                //            break;
                //        default:
                //            client.Host = "smtp.exmail.qq.com";//qq企业邮箱
                //            break;
                //    }
                //}
                #endregion

                client.Port = 465; //465

                //使用安全加密连接。
                client.EnableSsl = true;
                //不和请求一块发送。
                client.UseDefaultCredentials = false;
                //超时时间
                client.Timeout = 3000;

                //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
                client.Credentials = new NetworkCredential(FromMial, FromPass);///zk721215 -- "LHUKAXARGFBBSLPM"

                //如果发送失败，SMTP 服务器将发送 失败邮件告诉我  
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //发送
                client.Send(mailMessage);
                return 1;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(ex.Message);
                //throw ex;
                return 0;
            }
        }
        #endregion

        public static int SendMails(string email, string bodyStr, string title)
        {
            string fromMail = "kaixing_service@163.com";
            string toMail = email;
            MailMessage mailMessage = new MailMessage
            {
                //发件人
                From = new MailAddress(fromMail)
            };

            //收件人 可以添加多个收件人
            mailMessage.To.Add(new MailAddress(toMail));

            //mailMessage.CC 获取包含此电子邮件的抄送(CC)收件人的地址集合
            //邮件主题
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.Subject = "Hello";

            //邮件正文
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Body = bodyStr;

            //如果要发送html格式的消息，需要设置这个属性
            mailMessage.IsBodyHtml = true;

            //邮件内容即消息正文中中显示图片 
            //需要为图片指明src=‘cid:idname(资源id)‘
            //AlternateView htmlBody = AlternateView.CreateAlternateViewFromString("<img src=‘cid:zfp‘/>", null, "text/html");

            //然后在LinkedResource加入文件的绝对地址，和ContentType 例如image/gif，text/html...与http请求的响应报文中的ContentType一致
            //LinkedResource lr = new LinkedResource("1.gif", "image/gif");

            //绑定上文中指定的idname
            //lr.ContentId = "zfp";

            //添加链接资源
            //htmlBody.LinkedResources.Add(lr);

            //mailMessage.AlternateViews.Add(htmlBody);


            //创建邮件发送客户端
            try
            {
                //这里使用qq邮箱 需要在设置->账户下开启POP3/SMTP服务 和 IMAP / SMTP服务
                //qq邮箱的发件服务器smtp.qq.com  端口25
                SmtpClient sendClient = new SmtpClient("smtp.163.com", 25)
                {
                    //指定邮箱账号和密码
                    //在第三方客户端登陆qq邮箱时，密码是授权码
                    //登陆qq邮箱在设置->账户下可以生成授权码
                    Credentials = new NetworkCredential(fromMail, "LHUKAXARGFBBSLPM")
                };

                //指定如何发送电子邮件
                sendClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                //指定使用使用安全套接字ssl加密的链接

                sendClient.EnableSsl = true;
                sendClient.Send(mailMessage);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #region 163邮箱
        public static int SendMail(string email, string bodyStr)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = "smtp.163.com";//使用163的SMTP服务器发送邮件
                client.UseDefaultCredentials = true;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("kaixing_service@163.com", "LHUKAXARGFBBSLPM");//163的SMTP服务器需要用163邮箱的用户名和密码作认证，如果没有需要去163申请个,
                                                                                        //这里假定你已经拥有了一个163邮箱的账户，用户名为abc，密码为*******
                System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
                Message.From = new System.Net.Mail.MailAddress("kaixing_service@163.com");//这里需要注意，163似乎有规定发信人的邮箱地址必须是163的，而且发信人的邮箱用户名必须和上面SMTP服务器认证时的用户名相同
                                                                              //因为上面用的用户名abc作SMTP服务器认证，所以这里发信人的邮箱地址也应该写为abc@163.com
                Message.To.Add(email);
                //Message.To.Add("123456@qq.com");//将邮件发送给QQ邮箱
                Message.Subject = "凯行网密码重置";
                Message.Body = bodyStr;
                Message.SubjectEncoding = System.Text.Encoding.UTF8;
                Message.BodyEncoding = System.Text.Encoding.UTF8;
                Message.Priority = System.Net.Mail.MailPriority.High;
                Message.IsBodyHtml = true;
                client.Send(Message);
                return 1;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(ex.Message);
                return 0;
            }
        }
        #endregion

        #region 阿里邮箱发送
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="bodyStr">邮件内容</param>
        /// <param name="title">邮件标题</param>
        /// <returns>返回结果，成功与否</returns>
        public static int SendMail(string email, string bodyStr, string title)
        {
            //smtpClient.Host = "smtp.airkx.com";
            //smtpClient.Credentials = new System.Net.NetworkCredential("sale@airkx.com", "Airkx9898");
            //密码不是QQ密码，是qq账户设置里面的POP3/SMTP服务生成的key
            string authName = "sale@airkx.com";
            string password = "Airkx9898";

            MailMessage msg = new MailMessage(authName, email);
            msg.Body = bodyStr;
            msg.Subject = "凯行网密码重置";
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(authName, password);
            smtp.Port = 465;
            smtp.Host = "ssl.alibaba-inc.com";
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;
            try
            {
                smtp.Send(msg);
                return 1;
            }
            catch (SmtpException ex)
            {
                LoggerHelper.Error(ex.ToString());
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

        #region 获取时间戳
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
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

        #region 创建分页SQL
        public static string createPageSql(string sql, string orderby, int page, int pagenum)
        {
            string strsql = "select * from ( " +
                " SELECT ROW_NUMBER() OVER(" + orderby + ") AS Row, " +
                "" + sql +
                " ) as TT WHERE TT.Row between " + ((page - 1) * pagenum + 1) + " and " + (page * pagenum) + "";
            return strsql;
        }
        #endregion
    }
}
