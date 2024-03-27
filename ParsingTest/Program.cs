using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

internal class Program
{
    private static EdgeDriver Driver { get; set; } = null!;

    private static void Main(string[] args)
    {
        try
        {
            EdgeDriverService driverService = EdgeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            Driver = new EdgeDriver(driverService, new EdgeOptions())
            {
                Url = "https://www.citilink.ru/catalog/noutbuki/"
            };

            string s = Driver.PageSource;
            Regex regex = new(@"<a href=""/product/(?<space>.*?) e1259i3g0"">(?<val>.*?)</a>", RegexOptions.Compiled | RegexOptions.Singleline);
            MatchCollection matchCollection = regex.Matches(s);
            Console.WriteLine(matchCollection.Count);
            foreach (Match match in matchCollection)
            {
                Console.WriteLine(match.Value.Split("\"")[3].Replace("&quot;", ""));
            }

        }
        catch { }


        //try
        //{
        //    string url = $"https://www.citilink.ru/catalog/noutbuki/";
        //    Driver.Navigate().GoToUrl(url);
        //    Thread.Sleep(10000);

        //    for (int i = 1; i <= 20; i++)
        //        try
        //        {
        //            ReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.ClassName("e1259i3g0"));
        //            Thread.Sleep(10000);
        //            foreach (IWebElement element in elements)
        //            {
        //                element.
        //            }
        //        }
        //        catch { }
        //}
        //catch { }

        Driver.Close();
    }
}