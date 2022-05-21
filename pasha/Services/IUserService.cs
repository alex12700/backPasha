using pasha.Models;

namespace pasha.Services;

public interface IUserService
{
    public User Get(int id);
    public User Get(UserLogin userLogin);
}