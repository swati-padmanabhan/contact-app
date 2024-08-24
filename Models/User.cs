using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    internal class User
    {

        //primary key for the user table
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //indicates whether the user has admin access, default is true
        public bool IsAdmin { get; set; } = true;

        //indicates whether the user is active or not, default is true
        public bool IsActive { get; set; } = true;

        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public override string ToString()
        {
            return $"\nUser Information:\n" +
                   $"-----------------\n" +
                   $"UserId      : {UserId}\n" +
                   $"Name        : {FirstName} {LastName}\n" +
                   $"Admin       : {IsAdmin}\n" +
                   $"Active      : {IsActive}\n";
        }

    }
}
