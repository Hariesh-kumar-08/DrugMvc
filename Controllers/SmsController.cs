using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Twilio.TwiML;
using Twilio.Types;
using Twilio;
using Twilio.AspNet.Core;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;
using Twilio.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;

namespace DrugMvc.Controllers
{
    public class SmsController : Controller
    {
        public ActionResult SendSMS()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult SendSMS(string phone, string message)

        //{
        //    string AccountSid = "Account ID";
        //    string Token = "Auth Token";
        //    var twilio = new TwilioRestClient(AccountSid, Token);
        //    string number = "+91" + phone;
        //    var send = twilio.SendSmsMessage("+13183901909", number, message);
        //    TempData["successful"] = "SMS send Successfully";
        //    return RedirectToAction("sendsms");
        //}
    }
}
