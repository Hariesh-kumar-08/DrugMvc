using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Twilio.TwiML;
using Twilio.Types;
using Twilio;
using Twilio.AspNet.Core;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace DrugMvc.Controllers
{
    public class SmsController : TwilioController
    {
        public ActionResult Index()
        {
            var a = ConfigurationManager.AppSettings
        }
    }
}
