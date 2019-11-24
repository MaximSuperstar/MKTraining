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
            

            if (app.Contacts.Contact_ModifyChecker())
            {
                app.Contacts.Contacts_Modify("selected[]", icd_modified);
            }

            else
            {
                InitContactData contact_for_modification = new InitContactData("IVANOV");
                contact_for_modification.Firstname = "IVAN";
                contact_for_modification.Middlename = "IVANOVICH";
                app.Contacts.Create(contact_for_modification);
                app.Contacts.Contacts_Modify("selected[]", icd_modified);
            }
        }
    }
}
