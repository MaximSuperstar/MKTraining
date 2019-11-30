using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests:AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group_modificated = new GroupData("test_Modificated");
            group_modificated.Header = "test middlename_Modificated";
            group_modificated.Footer = "test lastname_Modificated";

            if (!app.Groups.Groups_ModifyChecker())
            {
                GroupData group_for_modification = new GroupData("");
                group_for_modification.Header = "group_for_modification";
                group_for_modification.Footer = "group_for_modification";
                app.Groups.Create(group_for_modification);
            }

            app.Groups.Groups_Modify("selected[]", group_modificated);
        }
    }
}
