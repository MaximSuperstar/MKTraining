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
            SelectGroup("selected[]");
            driver.FindElement(By.Name("edit")).Click();
            FillGroupForm(group);
            GroupUpdate();
            manager.Navigators.GoToGroupsPage();
            return this;
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
            TypeText(By.Name("group_header"), group.Name);
            TypeText(By.Name("group_footer"), group.Name);
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
