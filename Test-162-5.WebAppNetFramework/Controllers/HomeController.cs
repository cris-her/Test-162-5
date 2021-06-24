using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transbank.Webpay.WebpayPlus;
using System.Net;

namespace Test_162_5.WebAppNetFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ViewBag.Title = "Transbank .Net SDK";
            return View();
        }

    }
}