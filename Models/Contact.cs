using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    internal class Contact
    {

        //primary key for the contact table
        [Key]
        public int ContactId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //indicates whether the contact is active or not, default is true
        public bool IsActive { get; set; } = true;


        //navigation property for ContactDetails
        [ForeignKey("User")]
        public int UserId { get; set; }
        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();


        public override string ToString()
        {
            return $"\nContact Information:\n" +
                   $"--------------------\n" +
                   $"ContactId   : {ContactId}\n" +
                   $"Name        : {FirstName} {LastName}\n" +
                   $"Active      : {IsActive}\n";
        }

    }
}
