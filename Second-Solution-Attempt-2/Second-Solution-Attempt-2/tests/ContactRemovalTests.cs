using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.Contact_ModifyChecker())
            {
                InitContactData contact_for_removal = new InitContactData("IVANOV");
                contact_for_removal.Firstname = "IVAN";
                contact_for_removal.Middlename = "IVANOVICH";
                app.Contacts.Create(contact_for_removal);
            }

            List<InitContactData> oldContacts = app.Contacts.GetContactsList();            
            app.Contacts.RemoveContact("selected[]");            
            Thread.Sleep(5000);

            List<InitContactData> newContacts = app.Contacts.GetContactsList();

            InitContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (InitContactData group in newContacts)
            {
                 Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}
