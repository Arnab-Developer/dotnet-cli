using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreatedWithCli.WebApp.Models;
using CreatedWithCli.Lib;

namespace CreatedWithCli.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHelloService _helloService;

        public HomeController(IHelloService helloService)
        {
            _helloService = helloService;
        }

        public IActionResult Index(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("user name is blank.");
            }
            HelloViewModel helloServiceViewModel = new()
            {
                HelloMessage = _helloService.GetHelloMessage(userName)
            };
            return View("Index", helloServiceViewModel);
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
