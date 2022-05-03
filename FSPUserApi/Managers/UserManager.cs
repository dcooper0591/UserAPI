using FSPUserApi.Models;

namespace FSPUserApi.Managers
{
    public class UserManager
    {
        private List<User> users = new List<User>();
        private readonly DatabaseManager _databaseManager;

        public UserManager(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public User? GetUser(Guid userId)
        {
            User? userFound = _databaseManager.GetUser(userId);

            if (userFound != null)
            {
                return userFound;
            }
            else
            {
                return null;
            }

        }

        public Guid? AddUser(User user)
        {
            _databaseManager.SaveUser(user);
            if (_databaseManager.GetUser(user.Id) != null)
            {
                return user.Id;
            }
            else
            {
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            return _databaseManager.GetAllUsers();
        }
    }
}
