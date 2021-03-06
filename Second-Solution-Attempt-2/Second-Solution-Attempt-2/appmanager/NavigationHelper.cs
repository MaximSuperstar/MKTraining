﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
//



namespace WebAddressbookTests
{
    public class NavigationHelper:HelperBase
    {
        private string baseURL;
        
        public NavigationHelper(ApplicationManager manager, string baseURL)
            :base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/"
                && IsElementPresent(By.Name("searchstring")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToAccountPage()
        {
            if (driver.Url == baseURL + "/edit.php"
               && IsElementPresent(By.Name("submit")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnHomePage()
        {
            if (driver.Url == baseURL + "/"
               && IsElementPresent(By.Name("searchstring")))
            {                
                return;
            }            
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                 && IsElementPresent(By.Name("new")))
            {
                return;
            }            
            driver.FindElement(By.LinkText("groups")).Click();            
        }
    }
}
