﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests:AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.Groups_ModifyChecker())
            {
                GroupData group_for_removal = new GroupData("");
                group_for_removal.Header = "group_for_modification";
                group_for_removal.Footer = "group_for_modification";
                app.Groups.Create(group_for_removal);
            }

            app.Groups.RemoveGroup("selected[]");
        }       
    }
}
