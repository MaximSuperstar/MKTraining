using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests:AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("test_Modificated");
            newData.Header = "test middlename_Modificated";
            newData.Footer = "test lastname_Modificated";

            if (!app.Groups.Groups_ModifyChecker())
            {
                GroupData group_for_modification = new GroupData("");
                group_for_modification.Header = "group_for_modification";
                group_for_modification.Footer = "group_for_modification";
                app.Groups.Create(group_for_modification);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            GroupData oldData = oldGroups[0];
            app.Groups.Groups_Modify("selected[]", newData);
            List<GroupData> newGroups = app.Groups.GetGroupsList();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
