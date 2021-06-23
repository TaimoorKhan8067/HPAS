using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
namespace Hostel_Managment.Utilities
{
    public class MailUtility
    {
        MailAddress fromAddress, toAddress;
        const string fromPassword="hostelcfd";
        SmtpClient smtp;
        public MailUtility(string recieverrollno,string recievername)
        {
            string cfdemail = recieverrollno + "@cfd.nu.edu.pk";
            fromAddress = new MailAddress("hostelmanagmentcfd@gmail.com", "Hostel Managament");
            toAddress= new MailAddress(cfdemail, recievername);
              smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

        }

        public void send(string body, string subject)
        {
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try { smtp.Send(message); }
                catch(Exception e)
                {
                    SmsUtility sms = new SmsUtility();
                    string smsmessage = "Check Mail Utility "+e.Message;
                    string json = sms.SendSMSPOST("03105195204", smsmessage);
                }

            }
        }
        

    }
}



