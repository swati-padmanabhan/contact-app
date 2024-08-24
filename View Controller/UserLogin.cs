using ContactApp.Exceptions;
using ContactApp.Repositories;

namespace ContactApp.View_Controller
{
    internal class UserLogin
    {
        private readonly UserRepository _userRepository;
        private readonly AdminMenu _adminMenu;
        private readonly StaffMenu _staffMenu;

        public UserLogin(UserRepository userRepository, AdminMenu adminMenu, StaffMenu staffMenu)
        {
            _userRepository = userRepository;
            _adminMenu = adminMenu;
            _staffMenu = staffMenu;
        }

        public void Login()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("        Welcome to Contact App          ");
                    Console.WriteLine("========================================");
                    Console.WriteLine("\nPlease enter your User ID:");

                    // Handle format exception for invalid User ID input
                    int userId = Convert.ToInt32(Console.ReadLine());

                    var user = _userRepository.GetUserById(userId);
                    if (user == null)
                    {
                        throw new UserNotFoundException("\nUser not found. Please try again.");
                    }

                    if (!user.IsActive)
                    {
                        throw new UserInactiveException("\nUser is inactive and cannot perform any operations.");
                    }

                    Console.Clear();
                    Console.WriteLine($"\n        Welcome, {user.FirstName} {user.LastName}          \n");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    if (user.IsAdmin)
                    {
                        _adminMenu.DisplayMenu();
                    }
                    else
                    {
                        _staffMenu.DisplayMenu();
                    }
                }
                catch (UserNotFoundException ufe)
                {
                    Console.WriteLine(ufe.Message);
                }
                catch (UserInactiveException uie)
                {
                    Console.WriteLine(uie.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}