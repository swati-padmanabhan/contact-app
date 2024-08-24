using ContactApp.Models;

namespace ContactApp.Repositories
{

    //this class handles CRUD operations for contact
    internal class ContactRepository
    {
        //list to store contacts
        private List<Contact> _contacts = new List<Contact>();

        //constructor initializes the repository
        public ContactRepository() { }


        //retrieves a contact by their id
        public Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(u => u.ContactId == contactId);
            return contact;
        }

        //adds a new contact to the repository
        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }


        //updates an existing contact's information
        public void UpdateContact(Contact contact)
        {
            var existingContact = GetContactById(contact.ContactId);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.IsActive = contact.IsActive;
            }
        }

        //soft deletes a contact by setting their "IsActive" property to false
        public void DeleteContact(int contactId)
        {
            var contact = GetContactById(contactId);
            if (contact != null)
            {
                contact.IsActive = false;
            }
        }

        //retrieves all active contacts
        //filters out contacts whose "IsActive" property is false
        public List<Contact> GetAllContacts()
        {
            var contact = _contacts.Where(x => x.IsActive).ToList();
            return contact;
        }

    }
}
