using MaoUpFind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MaoUpFind.Factories
{
    public class F_SendEmail
    {
        //引數分別為 收件地址List, 信件標題(主旨), 信件內容
        //此方法回傳布林值，若寄信過程失敗將回傳false
        public bool IsDoingSendEmail(List<string> addressList, string yourMessageSubject,string yourMessageBody)
        {
            string yourUsername;
            string yourShowname;
            String yourPassword;
            yourUsername = "maoupfind@gmail.com";
            yourShowname = "毛起來找/開發小組";
            //因方便因素直接將密碼寫在程式碼內，但此行為非常不好，不要模仿
            yourPassword = "maoup1234";

            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(yourUsername, yourPassword);
                    MailMessage msgObj = new MailMessage();
                    foreach (var item in addressList)
                    {
                        msgObj.Bcc.Add(item);
                    }
                    msgObj.From = new MailAddress(yourUsername, yourShowname, System.Text.Encoding.UTF8);
                    msgObj.Subject = yourMessageSubject;
                    msgObj.Body = yourMessageBody;
                    client.Send(msgObj);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 通報協尋認養用寄信
        /// </summary>
        /// <param name="mailData"></param>
        /// <returns></returns>
        public VM_Info send(VM_Mail mailData)
        {
            VM_Info rInfo = new VM_Info();
            string yourUsername;
            string yourShowname;
            String yourPassword;
            string yourMessageSubject;
            string yourMessageBody;
            yourUsername = "maoupfind@gmail.com";
            yourShowname = "毛起來找/開發小組";
            yourPassword = "maoup1234";
            yourMessageSubject = $"毛起來找-{mailData.M_Subject}";
            yourMessageBody = mailData.M_Body;
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(yourUsername, yourPassword);

                    MailMessage msgObj = new MailMessage();
                    msgObj.IsBodyHtml = true;
                    msgObj.Bcc.Add(mailData.M_Address);
                    msgObj.From = new MailAddress(yourUsername, yourShowname, System.Text.Encoding.UTF8);
                    msgObj.Subject = yourMessageSubject;
                    msgObj.Body = yourMessageBody;
                    client.Send(msgObj);
                }
                rInfo.isSuccess = true;
            }
            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "寄送信件時發生錯誤!";
            }
            return rInfo;
        }
    }
}