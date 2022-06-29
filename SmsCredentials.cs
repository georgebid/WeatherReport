using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Text.Json;
using Twilio.Rest.Verify.V2.Service;

namespace WeatherReport
{
    internal class SmsCredentials
    {
        public void GetCredentials()
        {
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(username: accountSid, password: authToken);
        }
        
    }
}
