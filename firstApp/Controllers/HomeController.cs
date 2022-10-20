using firstApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public string GlobalUser;
        public string GlobalHost;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string Host = Request.Headers["Host"].ToString();
            ViewData["User-Agent"] = userAgent;
            ViewBag.Host = Host;
            return View();
        }

        public void Req()
        {
            string table = " ";

            foreach (var header in Request.Headers)
            {
                table += $"<tr><td>{header.Key}</td> <td>{header.Value}</td> </tr>";
            }
            Response.WriteAsync($"<table>{table}</table>");

            string userAgent = Request.Headers["User-Agent"].ToString();
            string Host = Request.Headers["Host"].ToString();
            GlobalUser = userAgent;
            GlobalHost = Host;


        }

        public void Resp()
        {
            /*            Response.StatusCode = 404;
                        Response.WriteAsync("error error error error error errorerrorerrorerrorerror errorerrorerrorerrorerrorerrorerrorerror errorerror error error error error error error error error errorerrorerrorerrorerror error error error error errorerrorerrorerrorerror error error error error error error error error errorerror error error error error errorerrorerrorerrorerror errorerror ");
                    */
            Response.GetType();
        
        
        }

        public void Resp2()
        {
            Response.StatusCode = 404;
            Response.WriteAsync("Who are you?");
        }

        public void Resp3()
        {
            Response.StatusCode = 404;
            Response.WriteAsync("Your father went for bread, the cashier had no change :)");
        }



        public IActionResult Log()
        {
            return View();
        }
        public IActionResult ContextError()
        {
            HttpContext.Response.WriteAsync("lishjerngouyiwgvouiywygihweyoighweiyv");
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
