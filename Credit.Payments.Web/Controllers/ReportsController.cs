using System.Collections;
using Credit.Payments.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Payments.Web.Controllers
{
    public class ReportsController : Controller
    {
        [HttpPost]
        public IActionResult Index(Account account)
        {
            int maxYears = 3;
            Hashtable years = new Hashtable();

            if (account.IsValid())
            {
                for (int i = 0; i < account.History.Length; i++)
                {
                    // If we don't have the key/row for the year
                    if (!years.ContainsKey(account.Date.Year))
                    {
                        // And we haven't reach the 'maxYears'
                        if (years.Count == maxYears)
                        {
                            break;
                        }

                        // Then add the year to the hastable with an array to hold the months
                        years.Add(account.Date.Year, new string[12]);
                    }

                    // Here we get the months of the year
                    string[] months = (string[])years[account.Date.Year];
                    // Set the value of history[i] for the current month in array
                    months[account.Date.Month - 1] = $"{account.History[i]}";
                    // Move one month to the past
                    account.Date = account.Date.AddMonths(-1);
                }

                return View(years);
            }

            return Redirect("Home/Index");
        }
    }
}