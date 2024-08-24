using ContactApp.Repositories;
using ContactApp.View_Controller;

namespace ContactApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            ContactRepository contactRepository = new ContactRepository();
            ContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository();

            AdminMenu adminMenu = new AdminMenu(userRepository);
            ContactMenu contactMenu = new ContactMenu(contactRepository);
            ContactDetailsMenu contactDetailsMenu = new ContactDetailsMenu(contactDetailsRepository, contactRepository);
            StaffMenu staffMenu = new StaffMenu(contactMenu, contactDetailsMenu);

            UserLogin userLogin = new UserLogin(userRepository, adminMenu, staffMenu);
            userLogin.Login();

        }

    }
}