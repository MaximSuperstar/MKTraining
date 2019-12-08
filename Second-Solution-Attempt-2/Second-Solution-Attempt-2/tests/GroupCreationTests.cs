using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests:AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("test");
            group.Header = "test middlename";
            group.Footer = "test lastname";            
            //***************************************************************
            //the next method returns groups
            //object of List class with type "GroupData"
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            //create a new group:
            app.Groups.Create(group);
            //looks for a new amount of groups:
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            // a checking that one group was added:
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            Console.WriteLine("Old groups ammount " + oldGroups.Count);
            Console.WriteLine("New groups ammount " + newGroups.Count);
            //***************************************************************
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            
            GroupData group = new GroupData("***XXX*****");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            //create a new group:
            app.Groups.Create(group);
            //looks for a new amount of groups:
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            // a checking that one group was added:
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            //***************************************************************
        }

        [Test]
        public void ErrorCreationTest()
        {

            GroupData group = new GroupData("error'creation");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            //create a new group:
            app.Groups.Create(group);
            //looks for a new amount of groups:
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            // a checking that one group was added:
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}
