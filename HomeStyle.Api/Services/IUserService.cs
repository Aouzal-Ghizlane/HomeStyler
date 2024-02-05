
using HomeStyler.Api.Data.Entities;


namespace VintageApp.Services
{


    public interface IUserService
    {
        Task<User> Login(string email, string password);
        Task<User> SignUp(string username, string email, string password);
    }
}
