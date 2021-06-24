using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_162_5.Web.Models;
using Transbank.Webpay.WebpayPlus;



namespace Test_162_5.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            /*
            var random = new Random();
            var buyOrder = random.Next(999999999).ToString();
            var sessionId = random.Next(999999999).ToString();
            var amount = random.Next(1000, 999999);
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var returnUrl = urlHelper.Action("NormalReturn", "WebpayPlus", null, Request.Url.Scheme);
            var result = Transaction.Create(buyOrder, sessionId, amount, returnUrl);

            ViewBag.BuyOrder = buyOrder;
            ViewBag.SessionId = sessionId;
            ViewBag.Amount = amount;
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Result = result;
            ViewBag.Action = result.Url;
            ViewBag.Token = result.Token;
            */
            return View();
        }

        public ActionResult Return()
        {
            string tokenWs = Request.Form["token_ws"];

            var response = Transaction.Commit(tokenWs);

            if (response.ResponseCode == 0)
            {
                //ViewBag.UrlRedirection = response.UrlRedirection;
                ViewBag.TokenWs = tokenWs;
                ViewBag.ResponseCode = response.ResponseCode;
                ViewBag.Amount = response.Amount;
                ViewBag.AuthorizationCode = response.AuthorizationCode;
            }

            return View();
        }

        public IActionResult Final()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
