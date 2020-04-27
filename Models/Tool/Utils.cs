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
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

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
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

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
            string FromPass = "LHUKAXARGFBBSLPM";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("凯行网", fromMail));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = title;
            //html or plain
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = bodyStr;
            bodyBuilder.TextBody = "邮件测试文本正文ken.io";
            message.Body = bodyBuilder.ToMessageBody();

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    //smtp服务器，端口，是否开启ssl
                    client.Connect("smtp.163.com", 465, true);
                    client.Authenticate(fromMail, FromPass);
                    client.Send(message);
                    client.Disconnect(true);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(ex.Message);
                return 0;
            }
        }

        #region 163邮箱
        public static int SendMail(string email, string bodyStr)
        {
            string fromEmail = "kaixing_service@163.com";     //发件人邮箱地址
            string emailSMTPHost = "smtp.163.com";  //邮箱SMTP服务器,用来发送邮件
            string emailSubject = "Email Subject";  //邮件主题
            string emailBody = bodyStr; //邮件内容
            string toEmail = email;   //要发送对象的邮箱地址

            string emailName = fromEmail;  //登陆邮箱的用户名，可以和发件人邮箱地址一样
            string emailPwd = "LHUKAXARGFBBSLPM";  //登陆邮箱的密码

            try
            {
                using (MailMessage msg = new MailMessage(fromEmail, toEmail, emailSubject, emailBody))
                {
                    msg.IsBodyHtml = true;  //设置邮件内容是否支持html格式
                    //msg.To.Add("zhangMao@sina.com");    //追加多个收件人邮箱，实现群发
                    msg.Priority = MailPriority.High;   //发送邮件的优先等级

                    System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(emailSMTPHost);
                    mailClient.UseDefaultCredentials = false;  //设置是否随请求一起发送
                    mailClient.Credentials = new System.Net.NetworkCredential(emailName, emailPwd);

                    //是否使用安全套接字层 (SSL) 加密连接. SmtpClient 使用 SSL，则为 true；否则为 false。默认值为 false。
                    mailClient.EnableSsl = true;

                    mailClient.Send(msg); //调用发送邮件方法
                    return 1;
                }
            }
            catch (Exception ex)
            {
                //发送失败：ex.Message;
                LoggerHelper.Error(ex.Message);
                return 0;
            }
        }
        #endregion

        #region 阿里邮箱发送
        // <summary>
        /// 发送邮件，使用SSL协议加密
        /// </summary>
        /// <param name="mailTitle">邮件标题</param>
        /// <param name="mailContent">邮件内容</param>
        /// <param name="mailAddress">收件人地址集合</param>
        public static int SendMailSSL(string email, string bodyStr)
        {

            //发件人邮箱地址。
            string FromMial = "kaixing_service@163.com"; ///   "kaixing_service@163.com"  "wuguang407906079@163.com"
            string FromPass = "LHUKAXARGFBBSLPM"; /// 授权码   "LHUKAXARGFBBSLPM"    "XPHVMFGAGWOXFMTH"

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //添加收件人
            //foreach (string address in mailAddress)
            //{
            //    msg.To.Add(address);
            //}
            msg.To.Add(email);
            //设置发件邮箱地址，发件人姓名，以及邮件编码
            msg.From = new MailAddress(FromMial, "凯行网", System.Text.Encoding.UTF8);
            //设置邮件标题
            msg.Subject = "kaixing";
            //设置邮件标题编码 
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //设置邮件内容
            msg.Body = bodyStr;
            //设置邮件内容编码
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            //指定是否是HTML邮件 
            msg.IsBodyHtml = true;
            //设置邮件优先级 
            msg.Priority = MailPriority.High;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //设置邮箱账号密码
            client.Credentials = new System.Net.NetworkCredential(FromMial, FromPass);
            //设置邮箱服务器使用的SSL协议端口 -可能个别要见服务器要求设置SSL协议端口
            client.Port = 465;
            //设置smtp服务器
            client.Host = "smtp.163.com";
            //使用ssl加密 
            client.EnableSsl = true;
            object userState = msg;
            try
            {
                //异步发送
                //client.SendAsync(msg, userState);
                //同步发送
                client.Send(msg);
                return 1;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                LoggerHelper.Error(ex.Message);
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
