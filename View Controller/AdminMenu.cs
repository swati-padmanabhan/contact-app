using ContactApp.Exceptions;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp.View_Controller
{

    //this class provides an interface to manage users
    internal class AdminMenu
    {
        private readonly UserRepository _userRepository;

        public AdminMenu(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("           Admin Management             ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add new User");
                Console.WriteLine("2. Modify existing User");
                Console.WriteLine("3. Delete User (soft)");
                Console.WriteLine("4. Display all Users");
                Console.WriteLine("5. Find User (GetById)");
                Console.WriteLine("6. Logout");
                Console.WriteLine("========================================");
                Console.Write("Select an option: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddNewUser();
                            break;
                        case 2:
                            ModifyUser();
                            break;
                        case 3:
                            DeleteUser();
                            break;
                        case 4:
                            DisplayAllUsers();
                            break;
                        case 5:
                            FindUser();
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

        private void AddNewUser()
        {
            try
            {
                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine();
                Console.WriteLine("Is Admin (true/false):");
                bool isAdmin = Convert.ToBoolean(Console.ReadLine());

                User newUser = new User
                {
                    UserId = _userRepository.GetAllUsers().Count + 1,
                    FirstName = firstName,
                    LastName = lastName,
                    IsAdmin = isAdmin
                };

                _userRepository.AddUser(newUser);
                Console.WriteLine("User added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void ModifyUser()
        {
            try
            {
                Console.WriteLine("Enter User Id to modify:");
                int userId = Convert.ToInt32(Console.ReadLine());

                var user = _userRepository.GetUserById(userId);
                if (user != null)
                {
                    Console.WriteLine("Enter First Name:");
                    user.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    user.LastName = Console.ReadLine();

                    _userRepository.UpdateUser(user);
                    Console.WriteLine("User updated successfully.");
                }
                else
                {
                    throw new UserNotFoundException("User not found.");
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
        private void DeleteUser()
        {
            try
            {
                Console.WriteLine("Enter User Id to delete:");
                int userId = Convert.ToInt32(Console.ReadLine());

                var user = _userRepository.GetUserById(userId);
                if (user != null)
                {
                    _userRepository.DeleteUser(userId);
                    Console.WriteLine("User deleted (soft) successfully.");
                }
                else
                {
                    throw new UserNotFoundException("User not found.");
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

        private void DisplayAllUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                if (users.Count == 0)
                {
                    throw new UserNotFoundException("No users found.");
                }

                foreach (var user in users)
                {
                    Console.WriteLine(user);
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

        private void FindUser()
        {
            try
            {
                Console.WriteLine("Enter User Id to find:");
                int userId = Convert.ToInt32(Console.ReadLine());

                var user = _userRepository.GetUserById(userId);
                if (user != null)
                {
                    Console.WriteLine(user);
                }
                else
                {
                    throw new UserNotFoundException("User not found.");
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