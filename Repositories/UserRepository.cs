using ContactApp.Models;

namespace ContactApp.Repositories
{

    //this class handles CRUD operations for user
    internal class UserRepository
    {
        //list to store users
        private List<User> _users = new List<User>();


        //constructor initializes the repository with some default values
        public UserRepository()
        {
            _users.Add(new User { UserId = 1, FirstName = "Admin", LastName = "User", IsAdmin = true });
            _users.Add(new User { UserId = 2, FirstName = "Staff", LastName = "Member", IsAdmin = false });
        }

        //retrieves a user by their id
        public User GetUserById(int userId)
        {
            var users = _users.FirstOrDefault(u => u.UserId == userId);
            return users;
        }

        //adds a new user to the repository
        public void AddUser(User user)
        {
            _users.Add(user);
        }


        //updates an existing user's information
        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.UserId);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.IsActive = user.IsActive;
            }
        }

        //soft deletes a user by setting their "IsActive" property to false
        //the user is not removed from the list but is marked as inactive
        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                user.IsActive = false;
            }
        }


        //retrieves all active users 
        //filters out users whose "IsActive" property is false
        public List<User> GetAllUsers()
        {
            var users = _users.Where(x => x.IsActive).ToList();
            return users;
        }
    }

}
