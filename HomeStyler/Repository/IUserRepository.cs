
using Homestyler.Models;

namespace HomeStyler.Repository;
public interface IUserRepository
{
    Task<User> Login(string email, string password);
    Task<User> SignUp(string username, string email, string password);
}
