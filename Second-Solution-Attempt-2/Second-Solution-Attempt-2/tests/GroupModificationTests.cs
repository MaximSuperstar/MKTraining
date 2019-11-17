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
            app.Groups.Groups_Modify(2, group_modificated);
        }
    }
}
