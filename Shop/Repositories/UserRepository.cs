using Shop.Models;

namespace Shop.Repositories
{
    public class UserRepository
    {
        public User Get(string userName, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "batman", Password = "password", Role = "Manager"});
            users.Add(new User { Id = 1, UserName = "robin", Password = "robin", Role = "Employee" });

            return users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
        }
    }
}
