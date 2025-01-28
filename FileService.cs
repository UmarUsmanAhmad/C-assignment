using System.Text.Json;
using Contactlist;

namespace ContactList;

public class FileService
{
    private readonly string fileName = "contacts.json";

    public List<Contact> LoadContacts()
    {
        if (!File.Exists(fileName)) return new List<Contact>(); 

        var json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
    }

    public void SaveContacts(List<Contact> contacts)
    {
        var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }

    public void ClearData()
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName); 
        }
    }
}
