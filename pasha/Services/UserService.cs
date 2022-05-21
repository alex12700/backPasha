using pasha.Models;
using pasha.Repositories;

namespace pasha.Services;

public class UserService : IUserService
{
    public User Get(int id)
    {
        var user = UserRepository.Users.FirstOrDefault(x => x.Id == id);
        return user;
    }

    public User Get(UserLogin userLogin)
    {
        var user = UserRepository.Users.FirstOrDefault(x =>
            x.UserName == userLogin.UserName && x.Password == userLogin.Password);
        return user;
    }
}