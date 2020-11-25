using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Web.Http;
using TakeABowApi.Common;


namespace TakeABowApi.Controllers
{
    public class UserController : ApiController
    {
        int num_user_id = 1000;

        TakeABowApi.Logic.Logic logic = new TakeABowApi.Logic.Logic();
        //UserController
        //Create V
        //Login  V
        //Update V


        //FeedbackController - 
        //Create V
        //GetAllFeedbackByUser V
        [HttpGet]
        [Route("api/user/test")]
        public bool Get()
        {
            return true;
        }

        /*עובד*/
        [HttpPost]
        [Route("api/user/createUser")]
        public bool CreateUsert(Common.User user)
        {
            User u = new User(user);
            bool isExist = logic.IsUserExist(u);
            if (isExist)
            {
                return false;
            }
            bool res = logic.saveNewUser(u);

            //api stuff
            return res;
        }

        /*עובד*/
        [HttpPost]
        [Route("api/user/updateUser")]
        public bool POST(User u)
        {
            
            User user = logic.FindUser(u);
            if (user==null)
                return false;
            if (logic.UpdateUser(u))
                return true;
            return false;
        }

        /*עובד להתחבר לקליינט*/
        [HttpGet]
        [Route("api/user/login")]
        public int login(int id, string password)
         {
           //int Attempts‏ = 0;
            User u = logic.Login(id, password);
            if(u == null)
            {
                //if (Attempts‏ < 3)
                //{
                //  Attempts‏++;
                //    return 0;
                //}
                return 0;
            }

            return u.Id;
        }
        //לחבר לקליינט
        
            //private void verify(string email) {
            //    try { 
            //        MailMessage mail = new MailMessage();
            //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //        mail.From = new MailAddress("your_email_address@gmail.com"); 
            //        mail.To.Add("to_address");
            //        mail.Subject = "Test Mail"; 
            //        mail.Body = "This is for testing SMTP mail from GMAIL";
            //        SmtpServer.Port = 587;
            //        SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password"); 
            //        SmtpServer.EnableSsl = true; SmtpServer.Send(mail); MessageBox.Show("mail Send"); 
            //    }
            //    catch (Exception ex) {
            //        MessageBox.Show(ex.ToString()); 
            //    }
            //}
        }
    }


        [HttpGet]
        [Route("api/user/deleteUser")]
       public bool GET(int id, string password)
        {
            bool d = logic.deleteUser(id, password);
            if(d==true)
                return true;
            return false;
        }
    }
}