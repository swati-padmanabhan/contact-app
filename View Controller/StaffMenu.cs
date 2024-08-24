namespace ContactApp.View_Controller
{
    internal class StaffMenu
    {
        private readonly ContactMenu _contactMenu;
        private readonly ContactDetailsMenu _contactDetailsMenu;

        public StaffMenu(ContactMenu contactMenu, ContactDetailsMenu contactDetailsMenu)
        {
            _contactMenu = contactMenu;
            _contactDetailsMenu = contactDetailsMenu;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("            Staff Management            ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Work on Contacts");
                Console.WriteLine("2. Work on Contact Details");
                Console.WriteLine("3. Logout");
                Console.WriteLine("========================================");
                Console.Write("Select an option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        _contactMenu.DisplayMenu();
                        break;
                    case 2:
                        _contactDetailsMenu.DisplayMenu();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
