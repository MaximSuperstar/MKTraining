using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class CyclesExamples
    {
        
        [Test]
        public void CyclesExample()
        {
            IWebDriver driver = new FirefoxDriver();
            int attempt = 0;
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt <10)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Cycle While N " + attempt);
                attempt++;
            }
            

            int[] digit = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Cycle For N " + i);
            }
            foreach (int element in digit)
            {
                Console.WriteLine("Cycle Foreach N " + element);    
            }
        }
    }
}
