using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

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
            

            if (!app.Contacts.Contact_ModifyChecker())
            {
                InitContactData contact_for_modification = new InitContactData("IVANOV");
                contact_for_modification.Firstname = "IVAN";
                contact_for_modification.Middlename = "IVANOVICH";
                app.Contacts.Create(contact_for_modification);
            }

            List<InitContactData> oldContacts = app.Contacts.GetContactsList();
            InitContactData oldData = oldContacts[0];
            app.Contacts.Contacts_Modify("selected[]", icd_modified);
            List<InitContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].LastNameContact = icd_modified.LastNameContact;
            Assert.AreEqual(oldContacts.Count, newContacts.Count);

            oldContacts.Sort();
            newContacts.Sort();    

            foreach (InitContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(icd_modified.LastNameContact, icd_modified.LastNameContact);
                }
            }
        }
    }
}
