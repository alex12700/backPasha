using pasha.Models;

namespace pasha.Repositories;

public class UserRepository
{
    public static List<User> Users = new List<User>()
    {
        new User()
        {
            Id = 1, Email = "test1@mail.ru", Password = "qwe123", Role = "admin", GivenName = "testUser1", UserName = "test1"
        }
    };
}