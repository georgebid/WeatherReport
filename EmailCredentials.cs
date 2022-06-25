using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Core;

namespace WeatherReport
{
    public class EmailCredentials
    {
        public SmtpClient GetEmailCredentials()
        {
            SmtpClient sender = null;
            using (sender = new SmtpClient(host: "smtp.gmail.com", 587))
            {
                //marking the use default credentials seems to clear out and existing data and avoid erroring.
                sender.UseDefaultCredentials = false;
                // THIS NEEDS TO MOVE

                //var username = Properties.Settings.Default.username;
                var username = ConfigurationManager.AppSettings["Username"];
                var password = ConfigurationManager.AppSettings["Password"];

                //sender.Credentials = new NetworkCredential("georginaweathertest@gmail.com", "Hmgd6961!");
                sender.Credentials = new NetworkCredential(username, password);
            };
            return sender;
        }
    }
}
