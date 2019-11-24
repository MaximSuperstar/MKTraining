using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contacts.Contact_ModifyChecker())
            {
                app.Contacts.RemoveContact("selected[]");
            }

            else
            {                
                InitContactData contact_for_removal = new InitContactData("IVANOV");
                contact_for_removal.Firstname = "IVAN";
                contact_for_removal.Middlename = "IVANOVICH";
                app.Contacts.Create(contact_for_removal);
                app.Contacts.RemoveContact("selected[]");
                Console.WriteLine("ContactRemovalTest -> Contact is removed");
            }
        }
    }
}
