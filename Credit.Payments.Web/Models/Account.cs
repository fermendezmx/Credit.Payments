using System;

namespace Credit.Payments.Web.Models
{
    public class Account
    {
        public string History { get; set; }
        public DateTime Date { get; set; }

        public bool IsValid()
        {
            // Here we use an arbitrary condition to validate the Date
            return !string.IsNullOrEmpty(History) && Date.Year > 1950;
        }
    }
}
