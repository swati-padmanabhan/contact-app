using ContactApp.Models;

namespace ContactApp.Repositories
{

    //this class handles CRUD operations for contact details
    internal class ContactDetailsRepository
    {
        //list to store contact details
        private List<ContactDetails> _contactDetails = new List<ContactDetails>();


        //constructor initializes the repository
        public ContactDetailsRepository() { }


        //retrieves a contact details by their id
        public ContactDetails GetContactDetailsById(int contactDetailsId)
        {
            var contactDetails = _contactDetails.FirstOrDefault(x => x.ContactDetailsId == contactDetailsId);
            return contactDetails;
        }

        //adds new contact details to the repository
        public void AddContactDetails(ContactDetails contactDetails)
        {
            _contactDetails.Add(contactDetails);
        }

        //updates an existing contact details' information
        public void UpdateContactDetails(ContactDetails contactDetails)
        {
            var existingDetails = GetContactDetailsById(contactDetails.ContactDetailsId);
            if (existingDetails != null)
            {
                existingDetails.Type = contactDetails.Type;
                existingDetails.Value = contactDetails.Value;
            }
        }

        //deletes contact details by removing them from the list
        //this method removes the contact details completely from the list
        public void DeleteContactDetails(int contactDetailsId)
        {
            var contactDetails = GetContactDetailsById(contactDetailsId);
            if (contactDetails != null)
            {
                _contactDetails.Remove(contactDetails);
            }
        }

        //retrieves all active contact details
        //filters out contact details whose 'IsActive' property is false
        public List<ContactDetails> GetAllContactDetails()
        {
            var contactDetails = _contactDetails.Where(x => x.IsActive).ToList();
            return contactDetails;
        }
    }
}
