﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TweetSharp;

namespace WebApp.Controllers
{
    public class TwitterAPIController : Controller
    {
       
            public static string _ConsumerKey = "79MxgKLaBEplt7HiQzkj3oqTp";
            public static string _ConsumerSecret = "7nAfcs3IWSf8zbZhP7f5D61RYIhvPljg9bhwyIPQUFhZlYp2nD";
            public static string _AccessToken = "1458372727140671495-s0nFlhJoqJ6MGYoQPxC2p7YZ1PF0fG";
            public static string _AccessTokenSecret = "YguTTU40A6KXoWfH0AHDY7k4gXItPM8po5ANPeymCIy2i";
            
            protected string GetTwitterSearchResult()
            {

            var tweets_search = new SearchOptions { Q = "#stocks", Resulttype = TwitterSearchResultType.Popular };
            TwitterService twService = new TwitterService(_ConsumerKey, _ConsumerSecret, _AccessToken, _AccessTokenSecret);
            TwitterSearchResult searchResult = twService.Search(tweets_search);
            //foreach (var tweet in searchResult.Statuses)
            //{

            //}
            return searchResult.RawSource;

            }


        public IActionResult Index()
        {
            var statuses = GetTwitterSearchResult();

            return View();
        }

    }
}
