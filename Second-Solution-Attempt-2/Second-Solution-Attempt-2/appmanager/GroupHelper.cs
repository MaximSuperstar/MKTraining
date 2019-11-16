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
    public class GroupHelper:HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            :base(manager)
        { }     

        public GroupHelper Create(GroupData group)
        {
            manager.Navigators.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigators.GoToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupData group)
        {
            manager.Navigators.GoToGroupsPage();
            SelectGroup(index);
            driver.FindElement(By.Name("edit")).Click();
            FillGroupForm(group);
            UpdateGroupCreation();
            manager.Navigators.GoToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper UpdateGroupCreation()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            manager.Navigators.GoToGroupsPage();
            driver.FindElement(By.XPath("(.//input[@name='selected[]'])[" + index + "]")).Click();            
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            SelectGroup(1);
            driver.FindElement(By.Name("delete")).Click();
            manager.Navigators.GoToGroupsPage();
            manager.Navigators.ReturnHomePage();
            return this;
        }
    }
}
