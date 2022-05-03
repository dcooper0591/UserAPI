using FSPUserApi.EntityFramework;
using FSPUserApi.Models;

namespace FSPUserApi.Managers
{
    public class DatabaseManager
    {
        private readonly UserDbContext _userDbContext;
        public DatabaseManager(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = _userDbContext.User.ToList();
            return userList;
        }

        public void SaveUser(User user)
        {
            _userDbContext.User.Add(user);
            _userDbContext.SaveChanges();
        }

        public User? GetUser(Guid guid)
        {
            return _userDbContext.User.FirstOrDefault(x=>x.Id == guid);
        }
    }
}
