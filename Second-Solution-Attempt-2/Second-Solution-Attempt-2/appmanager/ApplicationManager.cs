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
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            contactHelper = new ContactHelper(this);
            groupHelper = new GroupHelper(this);            
        }
        //destructor
        ~ApplicationManager()
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
        //static method
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigators.OpenHomePage();
                app.Value = newInstance;                
            }
            return app.Value; 
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
    }
}
