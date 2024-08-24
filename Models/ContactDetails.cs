using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    internal class ContactDetails
    {

        //primary key for the contact details table
        [Key]
        public int ContactDetailsId { get; set; }


        public string Type { get; set; }

        public string Value { get; set; }

        //indicates whether the contact detail is active or not, default is true
        public bool IsActive { get; set; } = true;

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        //navigation property to Contact
        public Contact Contact { get; set; }

        public override string ToString()
        {
            return $"\nContact Details Information:\n" +
                   $"----------------------------\n" +
                   $"ContactDetailsId : {ContactDetailsId}\n" +
                   $"Type             : {Type}\n" +
                   $"Value            : {Value}\n" +
                   $"ContactId        : {ContactId}\n" +
                   $"Active           : {IsActive}\n";
        }

    }
}
