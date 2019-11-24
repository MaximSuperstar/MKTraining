using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactHelper:HelperBase
    {
        protected bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager)
            :base(manager)
        {}
        public void InitContactCreation(InitContactData icd)
        {
            manager.Navigators.GoToAccountPage();
            TypeText(By.Name("firstname"), icd.Firstname);
            TypeText(By.Name("middlename"), icd.Firstname);
            TypeText(By.Name("lastname"), icd.Firstname);
        }



        public ContactHelper SelectContact(string index)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public ContactHelper Create(InitContactData icd)
        {
            InitContactCreation(icd);
            SubmitContactCreation();
            manager.Navigators.ReturnHomePage();
            return this;
        }
        public ContactHelper Contacts_Modify(string index, InitContactData icd_modified)
        {
            manager.Navigators.OpenHomePage();
            SelectContact(index);
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
            InitContactCreation(icd_modified);
            SubmitContactCreation();
            manager.Navigators.ReturnHomePage();
            return this;
        }

        public bool Contact_ModifyChecker()
        {
            manager.Navigators.OpenHomePage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                Console.WriteLine("Contact_ModifyChecker -> contact was found");
                return true;
            }
            else
            {
                Console.WriteLine("Contact_ModifyChecker -> contact was not found");
                return false;
            }
        }
        public ContactHelper RemoveContact(string index)
        {
            manager.Navigators.OpenHomePage();
            SelectContact(index);
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            manager.Navigators.ReturnHomePage();
            return this;
        }
        //delete--cancel confirmation methods//////////////////////////
        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        /////////////////////////////////////////////////////////////////
    }
}
