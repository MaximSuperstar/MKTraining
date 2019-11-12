using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper:HelperBase
    {    
        public ContactHelper(ApplicationManager manager)
            :base(manager)
        {}
        public void InitContactCreation(InitContactData icd)
        {
            manager.navigator.GoToAccountPage();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(icd.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(icd.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(icd.Lastename);            
        }
        public void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public ContactHelper Create(InitContactData icd)
        {
            InitContactCreation(icd);
            SubmitContactCreation();
            manager.navigator.ReturnHomePage();
            return this;
        }
    }
}
