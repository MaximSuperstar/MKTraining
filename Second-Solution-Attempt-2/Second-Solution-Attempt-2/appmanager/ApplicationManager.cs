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
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected ContactHelper contactHelper;
        protected GroupHelper groupHelper;
        protected IWebDriver driver;

        //protected ApplicationManager driver3;
        protected string baseURL;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            contactHelper = new ContactHelper(this);
            groupHelper = new GroupHelper(this);            
        }
        //-----properties
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Auth { get { return loginHelper; } }
        public NavigationHelper Navigators { get { return navigationHelper; } }
        public ContactHelper Contacts { get { return contactHelper; } }
        public GroupHelper Groups { get { return groupHelper; } }
        
        //------Method Stop
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
