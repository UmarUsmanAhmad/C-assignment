using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ContactList;
using Contactlist;

namespace ContactList.Tests
{
    [TestClass]
    public class ContactManagerTests
    {
        private FileService fileService;

        [TestInitialize]
        public void Setup()
        {
            fileService = new FileService();
            fileService.ClearData(); 
        }

        [TestMethod]
        public void AddContact_ShouldAddNewContact()
        {
            var manager = new ContactManager(fileService);

            manager.AddContact("Usman", "12345", "usman@hotmail.com");

            var contacts = manager.ListContacts();
            Assert.AreEqual(1, contacts.Count);
            Assert.AreEqual("Usman", contacts[0].Name);
        }

        [TestMethod]
        public void ListContacts_ShouldReturnContacts()
        {
            var manager = new ContactManager(fileService);

            manager.AddContact("Umar", "67890", "umar@gmail.com");

            var contacts = manager.ListContacts();
            Assert.AreEqual(1, contacts.Count);
            Assert.AreEqual("Umar", contacts[0].Name);
        }
    }
}
