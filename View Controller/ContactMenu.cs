using ContactApp.Exceptions;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp.View_Controller
{
    internal class ContactMenu
    {
        private readonly ContactRepository _contactRepository;

        public ContactMenu(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("          Contact Management            ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add new Contact");
                Console.WriteLine("2. Modify Contact");
                Console.WriteLine("3. Delete Contact (soft)");
                Console.WriteLine("4. Display all Contacts");
                Console.WriteLine("5. Find Contact (GetById)");
                Console.WriteLine("6. Logout");
                Console.WriteLine("========================================");
                Console.Write("Select an option: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddNewContact();
                            break;
                        case 2:
                            ModifyContact();
                            break;
                        case 3:
                            DeleteContact();
                            break;
                        case 4:
                            DisplayAllContacts();
                            break;
                        case 5:
                            FindContact();
                            break;
                        case 6:
                            return;
                        default:
                            throw new InvalidChoiceException("Invalid choice, Please Choose Between 1 and 6 only...");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter a number.");
                }
                catch (InvalidChoiceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
        }
        private void AddNewContact()
        {
            try
            {
                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine();

                Contact newContact = new Contact
                {
                    ContactId = _contactRepository.GetAllContacts().Count + 1,
                    FirstName = firstName,
                    LastName = lastName
                };

                _contactRepository.AddContact(newContact);
                Console.WriteLine("Contact added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the contact: {ex.Message}");
            }
        }
        private void ModifyContact()
        {
            try
            {
                Console.WriteLine("Enter Contact Id to modify:");
                int contactId = Convert.ToInt32(Console.ReadLine());

                var contact = _contactRepository.GetContactById(contactId);
                if (contact != null)
                {
                    Console.WriteLine("Enter First Name:");
                    contact.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    contact.LastName = Console.ReadLine();

                    _contactRepository.UpdateContact(contact);
                    Console.WriteLine("Contact updated successfully.");
                }
                else
                {
                    throw new ContactNotFoundException("Contact not found.");
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ContactNotFoundException cfe)
            {
                Console.WriteLine(cfe.Message);
            }

        }

        private void DeleteContact()
        {
            try
            {
                Console.WriteLine("Enter Contact Id to delete:");
                int contactId = Convert.ToInt32(Console.ReadLine());

                var contact = _contactRepository.GetContactById(contactId);
                if (contact != null)
                {
                    _contactRepository.DeleteContact(contactId);
                    Console.WriteLine("Contact deleted (soft) successfully.");
                }
                else
                {
                    throw new ContactNotFoundException("Contact not found.");
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ContactNotFoundException cfe)
            {
                Console.WriteLine(cfe.Message);
            }
        }

        private void DisplayAllContacts()
        {
            try
            {
                var contacts = _contactRepository.GetAllContacts();
                if (contacts.Count == 0)
                {
                    throw new ContactNotFoundException("No contacts found.");
                }

                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            catch (ContactNotFoundException cfe)
            {
                Console.WriteLine(cfe.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void FindContact()
        {
            try
            {
                Console.WriteLine("Enter Contact Id to find:");
                int contactId = Convert.ToInt32(Console.ReadLine());

                var contact = _contactRepository.GetContactById(contactId);
                if (contact != null)
                {
                    Console.WriteLine(contact);
                }
                else
                {
                    throw new ContactNotFoundException("Contact not found.");
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ContactNotFoundException cfe)
            {
                Console.WriteLine(cfe.Message);
            }
        }
    }
}
