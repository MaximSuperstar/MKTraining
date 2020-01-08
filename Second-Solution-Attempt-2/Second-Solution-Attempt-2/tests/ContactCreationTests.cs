using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            InitContactData icd = new InitContactData("Kolpakov");
            icd.Firstname = "Maxim5544";
            icd.Middlename = "Vlad334";

            List<InitContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Create(icd);
            List<InitContactData> newContacts = app.Contacts.GetContactsList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }
        [Test]
        public void ShortContactCreationTest()
        {
            InitContactData icd = new InitContactData("K");
            icd.Firstname = "MMM";
            icd.Middlename = "V";

            List<InitContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Create(icd);
            List<InitContactData> newContacts = app.Contacts.GetContactsList();
            Assert.AreEqual(oldContacts.Count +1, newContacts.Count);
        }
    }
}
