using System;
namespace ContactListAssignment;
using System.Text.Json;


public class ContactManager
{
    private readonly string fileName = "contacts.json";
    private List<Contact> contacts = new List<Contact>();

    public ContactManager()
    {
        if (File.Exists(fileName))
        {
            var json = File.ReadAllText(fileName);
            contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
    }

    public void AddContact(string name, string phone, string email)
    {
        contacts.Add(new Contact { Name = name, Phone = phone, Email = email });
        SaveContacts();
    }

    public List<Contact> ListContacts()
    {
        return contacts;
    }

    private void SaveContacts()
    {
        var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }
}


