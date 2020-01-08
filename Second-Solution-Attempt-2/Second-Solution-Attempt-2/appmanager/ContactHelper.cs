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

        public List<InitContactData> GetContactsList()
        {
            List<InitContactData> Contacts = new List<InitContactData>();
            manager.Navigators.OpenHomePage();

            IWebElement contactTable = driver.FindElement(By.TagName("table"));
            List<IWebElement> tableRows = contactTable.FindElements(By.TagName("tr")).ToList();

            for (int i = 1; i<tableRows.Count; i++)
            {
                IWebElement tableRow = tableRows[i];
                List<IWebElement> cells = tableRow.FindElements(By.TagName("td")).ToList();

                InitContactData lastNameContact = new InitContactData(cells[1].Text + " " + cells[2].Text);
                lastNameContact.Id = tableRow.FindElement(By.TagName("input")).GetAttribute("value");
            
                Contacts.Add(lastNameContact);
            }
            return Contacts;
        }

        public ContactHelper SelectContact(string index)
        {
            manager.Navigators.OpenHomePage();
            driver.FindElement(By.Name(index)).Click();
            return this;
        }

        public void SubmitContactCreation()
        {                   
            driver.FindElement(By.Name("submit")).Click();
        }
        public void UpdateContactCreation()
        {
            driver.FindElement(By.Name("update")).Click();
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
            SelectContact(index);
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
            InitContactCreation(icd_modified);
            UpdateContactCreation();
            manager.Navigators.ReturnHomePage();
            return this;
        }
        public void InitContactCreation(InitContactData icd)
        {
            TypeText(By.Name("firstname"), icd.Firstname);
            TypeText(By.Name("middlename"), icd.Middlename);
            TypeText(By.Name("lastname"), icd.Lastname);
        }

        public bool Contact_ModifyChecker()
        {
            manager.Navigators.OpenHomePage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                return true;
            }
            else
            {
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
