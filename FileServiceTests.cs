using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using ContactList;
using Contactlist;

namespace ContactList.Tests
{
    [TestClass]
    public class FileServiceTests
    {
        private FileService fileService;

        [TestInitialize]
        public void Setup()
        {
            fileService = new FileService();
            fileService.ClearData();
        }

        [TestMethod]
        public void SaveContacts_ShouldWriteToFile()
        {
            var contacts = new List<Contact>
            {
                new Contact { Name = "Alice", Phone = "99999", Email = "alice@example.com" }
            };

            fileService.SaveContacts(contacts);

            var loadedContacts = fileService.LoadContacts();
            Assert.AreEqual(1, loadedContacts.Count);
            Assert.AreEqual("Alice", loadedContacts[0].Name);
        }

        [TestMethod]
        public void LoadContacts_ShouldReturnEmptyListIfFileDoesNotExist()
        {
            fileService.ClearData();
            var contacts = fileService.LoadContacts();
            Assert.AreEqual(0, contacts.Count);
        }
    }
}
