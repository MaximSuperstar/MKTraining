using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            InitContactData icd_modified = new InitContactData("K_Modificated");
            icd_modified.Firstname = "M_Modificated";
            icd_modified.Middlename = "V_Modificated";
            app.Contacts.Contacts_Modify("4", icd_modified);
        }
    }
}
