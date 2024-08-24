using ContactApp.Exceptions;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp.View_Controller
{
    internal class ContactDetailsMenu
    {
        private readonly ContactDetailsRepository _contactDetailsRepository;
        private readonly ContactRepository _contactRepository;

        public ContactDetailsMenu(ContactDetailsRepository contactDetailsRepository, ContactRepository contactRepository)
        {
            _contactDetailsRepository = contactDetailsRepository;
            _contactRepository = contactRepository;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        Contact Details Management      ");
                Console.WriteLine("========================================");
                Console.WriteLine("\nContact Details Menu:");
                Console.WriteLine("1. Add new Contact Details");
                Console.WriteLine("2. Modify Contact Details");
                Console.WriteLine("3. Delete Contact Details (hard)");
                Console.WriteLine("4. Display all Contact Details");
                Console.WriteLine("5. Find Contact Details (GetById)");
                Console.WriteLine("6. Logout");
                Console.WriteLine("========================================");
                Console.Write("Select an option: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddNewContactDetails();
                            break;
                        case 2:
                            ModifyContactDetails();
                            break;
                        case 3:
                            DeleteContactDetails();
                            break;
                        case 4:
                            DisplayAllContactDetails();
                            break;
                        case 5:
                            FindContactDetails();
                            break;
                        case 6:
                            return;
                        default:
                            throw new InvalidChoiceException("Invalid choice, Please Choose Between 1 and 6 only...");

                    }
                }
                catch (InvalidChoiceException ice)
                {
                    Console.WriteLine(ice.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                Console.ReadKey();
            }
        }
        private void AddNewContactDetails()
        {
            try
            {
                Console.WriteLine("Enter Contact ID to add details to:");
                int contactId = Convert.ToInt32(Console.ReadLine());
                var contact = _contactRepository.GetContactById(contactId);
                if (contact != null)
                {
                    Console.WriteLine("Enter Type (number/email):");
                    string type = Console.ReadLine();

                    Console.WriteLine("Enter Value (actual email or number):");
                    string value = Console.ReadLine();

                    ContactDetails newContactDetails = new ContactDetails
                    {
                        ContactDetailsId = _contactDetailsRepository.GetAllContactDetails().Count + 1,
                        Type = type,
                        Value = value,
                        ContactId = contactId,
                        Contact = contact
                    };

                    contact.ContactDetails.Add(newContactDetails);
                    _contactDetailsRepository.AddContactDetails(newContactDetails);
                    Console.WriteLine("Contact details added successfully.");
                }

                else
                {
                    throw new UserNotFoundException("Contact not found.");
                }
            }
            catch (UserNotFoundException ufe)
            {
                Console.WriteLine(ufe.Message);
            }

            catch (FormatException fe)
            {
                Console.WriteLine("Input format is incorrect. Please enter valid data.");
            }

        }


        private void ModifyContactDetails()
        {
            try
            {
                Console.WriteLine("Enter Contact Details Id to modify:");
                int contactDetailsId = Convert.ToInt32(Console.ReadLine());

                var contactDetails = _contactDetailsRepository.GetContactDetailsById(contactDetailsId);
                if (contactDetails != null)
                {
                    Console.WriteLine("Enter Type (number/email):");
                    contactDetails.Type = Console.ReadLine();

                    Console.WriteLine("Enter Value (actual email or number):");
                    contactDetails.Value = Console.ReadLine();

                    _contactDetailsRepository.UpdateContactDetails(contactDetails);
                    Console.WriteLine("Contact details updated successfully.");
                }

                else
                {
                    throw new UserNotFoundException("Contact details not found.");
                }
            }
            catch (UserNotFoundException ufe)
            {
                Console.WriteLine(ufe.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void DeleteContactDetails()
        {
            try
            {
                Console.WriteLine("Enter Contact Details Id to delete:");
                int contactDetailsId = Convert.ToInt32(Console.ReadLine());

                var contactDetails = _contactDetailsRepository.GetContactDetailsById(contactDetailsId);
                if (contactDetails != null)
                {
                    _contactDetailsRepository.DeleteContactDetails(contactDetailsId);
                    Console.WriteLine("Contact details deleted successfully.");
                }
                else
                {
                    throw new UserNotFoundException("Contact details not found.");
                }
            }
            catch (UserNotFoundException ufe)
            {
                Console.WriteLine(ufe.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void DisplayAllContactDetails()
        {
            try
            {
                var contactDetailsList = _contactDetailsRepository.GetAllContactDetails();
                if (contactDetailsList.Count == 0)
                {
                    throw new ContactDetailsNotFoundException("No contact details found.");
                }

                foreach (var contactDetails in contactDetailsList)
                {
                    Console.WriteLine(contactDetails);
                }
            }
            catch (ContactDetailsNotFoundException cde)
            {
                Console.WriteLine(cde.Message);
            }
        }

        private void FindContactDetails()
        {
            try
            {
                Console.WriteLine("Enter Contact Details Id to find:");
                int contactDetailsId = Convert.ToInt32(Console.ReadLine());

                var contactDetails = _contactDetailsRepository.GetContactDetailsById(contactDetailsId);
                if (contactDetails != null)
                {
                    Console.WriteLine(contactDetails);
                }
                else
                {
                    throw new UserNotFoundException("Contact details not found.");
                }
            }
            catch (UserNotFoundException ufe)
            {
                Console.WriteLine(ufe.Message);
            }

            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }
}
