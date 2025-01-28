using System;
using Contactlist;

namespace ContactList;

class Program
{
    static void Main()
    {
        var fileService = new FileService();
        var manager = new ContactManager(fileService);

        while (true)
        {
            Console.WriteLine("\nContact Manager");
            Console.WriteLine("1. List all contacts");
            Console.WriteLine("2. Add a new contact");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListAllContacts(manager);
                    break;
                case "2":
                    AddNewContact(manager);
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ListAllContacts(ContactManager manager)
    {
        var contacts = manager.ListContacts();
        if (contacts.Count > 0)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}");
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
    }

    static void AddNewContact(ContactManager manager)
    {
        Console.Write("Enter name: ");
        var name = Console.ReadLine();

        Console.Write("Enter phone: ");
        var phone = Console.ReadLine();

        Console.Write("Enter email: ");
        var email = Console.ReadLine();

        manager.AddContact(name, phone, email);
        Console.WriteLine("Contact added successfully!");
    }
}
