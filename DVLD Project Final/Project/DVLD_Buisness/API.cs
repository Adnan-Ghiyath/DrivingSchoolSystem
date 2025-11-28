using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class API
    {

        ISend_API send_API;
        public API(ISend_API _API)
        {
            send_API = _API;
        }
        public void Send(string Subject,string Body)
        {
            send_API.Send(Subject, Body);
        }

    }
    public interface ISend_API
    {
        void Send(string Subject, string Body);
    }
    public class Email_API : ISend_API
    {
        clsPerson cls = new clsPerson();
        public void Send(string Subject, string Body)
        {
            try
            {
                string fromEmail = "ddnanworker820@gmail.com "; // بريد المرسل
                string fromPassword = "spprbfivlbelkkmi"; // كلمة مرور التطبيق
                string toEmail = cls.Email; // بريد المستلم

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = Subject;
                mail.Body = Body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                // Console.WriteLine("✅ تم إرسال الإيميل بنجاح!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No " + ex.Message);
            }
        }
    }
    public class SMS_API : ISend_API
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        // أنماط الأزرار والأيقونات
        const uint MB_OK = 0x00000000;
        const uint MB_OKCANCEL = 0x00000001;
        const uint MB_YESNO = 0x00000004;

        const uint MB_ICONINFORMATION = 0x00000040;
        const uint MB_ICONWARNING = 0x00000030;
        const uint MB_ICONERROR = 0x00000010;
        public void Send(string Subject, string Body)
        {

            // عرض رسالة بسيطة
            MessageBox(IntPtr.Zero, "لا يمكننا ارسال رسال لأننا لا نملك مال 😀", Body, MB_OK | MB_ICONINFORMATION);

            // مثال آخر مع أزرار نعم/لا
            int result = MessageBox(IntPtr.Zero, Subject, "تأكيد", MB_YESNO | MB_ICONWARNING);

            if (result == 6) // 6 = زر "نعم"
            {
                Console.WriteLine("تم اختيار نعم!");
            }
            else
            {
                Console.WriteLine("تم اختيار لا!");
            }
        }
    }



}