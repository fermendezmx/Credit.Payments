# Credit payments
The purpose of this repository is to build a web application that creates a report related to the payment history of non-bank credits.

Given the historic payments and the most recent date of the historic, we need to create a table that displays the historic (with observation key) by year and month (last 3 years tops).

The table should looks like the example shown in *(A)*:

![](https://github.com/fermendezmx/Credit.Payments/blob/master/Credit.Payments.Web/wwwroot/img/report.png)

And this is the solution provided:

![](https://github.com/fermendezmx/Credit.Payments/blob/master/Credit.Payments.Web/wwwroot/img/welcome.png)

```csharp
public Hashtable Solution(string history, DateTime date)
{
    int maxYears = 3;
    Hashtable years = new Hashtable();

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
            years.Add(date.Year, new string[12]);
        }

        // Here we get the months of the year
        string[] months = (string[])years[date.Year];
        // Set the value of history[i] for the current month in array
        months[date.Month - 1] = $"{history[i]}";
        // Move one month to the past
        date = date.AddMonths(-1);
    }

    return years;
}
```

![](https://github.com/fermendezmx/Credit.Payments/blob/master/Credit.Payments.Web/wwwroot/img/result.png)
