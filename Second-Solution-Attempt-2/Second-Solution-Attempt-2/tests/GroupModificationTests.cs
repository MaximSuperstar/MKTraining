using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests:TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("test_Modificated");
            newGroupData.Header = "test middlename_Modificated";
            newGroupData.Footer = "test lastname_Modificated";
            app.Groups.Modify(1, newGroupData);
        }
    }
}
