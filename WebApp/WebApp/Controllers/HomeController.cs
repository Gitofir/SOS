using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using TweetSharp;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("Denied")]
        public IActionResult Denied()
        {
            return View();
        }

        ///* TWITTER API */
        ///*------------------------------------------------*/

        //public static string _ConsumerKey = "79MxgKLaBEplt7HiQzkj3oqTp";
        //public static string _ConsumerSecret = "7nAfcs3IWSf8zbZhP7f5D61RYIhvPljg9bhwyIPQUFhZlYp2nD";
        //public static string _AccessToken = "1458372727140671495-s0nFlhJoqJ6MGYoQPxC2p7YZ1PF0fG";
        //public static string _AccessTokenSecret = "YguTTU40A6KXoWfH0AHDY7k4gXItPM8po5ANPeymCIy2i";

        //protected TwitterSearchResult GetTwitterSearchResult()
        //{

        //    var tweets_search = new SearchOptions { Q = "#stocks", Resulttype = TwitterSearchResultType.Popular };
        //    TwitterService twService = new TwitterService(_ConsumerKey, _ConsumerSecret, _AccessToken, _AccessTokenSecret);
        //    TwitterSearchResult searchResult = twService.Search(tweets_search);
        //    return searchResult;
        //}

       
    }
}


