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



        public GroupHelper Groups_Modify(string groupName, GroupData group)
        {
            manager.Navigators.GoToGroupsPage(); 
            SelectGroup(groupName);
            driver.FindElement(By.Name("edit")).Click();
            FillGroupForm(group);
            GroupUpdate();
            manager.Navigators.GoToGroupsPage();
            return this;
        }

        //GetGroupsList() method returns a list of groups:
        public List<GroupData> GetGroupsList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigators.GoToGroupsPage();
            driver.FindElements(By.CssSelector("span.group"));
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                GroupData group = new GroupData(element.Text);
                group.Id = element.FindElement(By.TagName("input")).GetAttribute("value");
                //group.
                groups.Add(group);
            }
            return groups;
        }

        public bool Groups_ModifyChecker()
        {
            manager.Navigators.GoToGroupsPage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper GroupUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SelectGroup(string groupName)
        {
            manager.Navigators.GoToGroupsPage();
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            TypeText(By.Name("group_name"), group.Name);
            TypeText(By.Name("group_header"), group.Header);
            TypeText(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper RemoveGroup(string groupName)
        {
            SelectGroup(groupName);
            driver.FindElement(By.Name("delete")).Click();
            manager.Navigators.GoToGroupsPage();
            manager.Navigators.ReturnHomePage();
            return this;
        }
    }
}
