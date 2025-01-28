using Contactlist;

namespace ContactList;

public class ContactManager
{
    private readonly List<Contact> contacts;
    private readonly FileService fileService;

    public ContactManager(FileService fileService)
    {
        this.fileService = fileService;
        contacts = fileService.LoadContacts(); 
    }

    public void AddContact(string name, string phone, string email)
    {
        contacts.Add(new Contact { Name = name, Phone = phone, Email = email });
        fileService.SaveContacts(contacts); 
    }

    public List<Contact> ListContacts()
    {
        return contacts;
    }
}
