using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            InitContactData icd = new InitContactData("Kolpakov");
            icd.Firstname = "Maxim2";
            icd.Middlename = "Vladimirovitch";
            app.Contacts.Create(icd);
        }
        [Test]
        public void ShortContactCreationTest()
        {
            InitContactData icd = new InitContactData("K");
            icd.Firstname = "M";
            icd.Middlename = "V";            
            app.Contacts.Create(icd);           
        }
    }
}
