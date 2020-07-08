using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Credit.Payments.Web.Models;
using System.Collections;

namespace Credit.Payments.Web.Controllers
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
            int maxYears = 3;
            Hashtable years = new Hashtable();
            DateTime date = new DateTime(2018, 10, 30);
            string history = "111111111111111111111111";

            for (int i = 0; i < history.Length; i++)
            {
                // If we don't have the key/row for the year
                if (!years.ContainsKey(date.Year))
                {
                    // And we haven't reach the 'maxYears'
                    if (years.Count == maxYears)
                    {
                        break;
                    }

                    // Then add the year to the hastable with an array to hold the months
                    years.Add(date.Year, new char[12]);
                }

                // Here we get the months of the year
                char[] months = (char[])years[date.Year];
                // Set the value of history[i] for the current month in array
                months[date.Month - 1] = history[i];
                // Move one month to the past
                date = date.AddMonths(-1);
            }

            return View(years);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
