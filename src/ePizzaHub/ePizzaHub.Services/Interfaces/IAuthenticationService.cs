using ePizzaHub.Entities;

namespace ePizzaHub.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> CreateUser(User user, string password);

        Task<bool> SignOut();

        Task<User> AuthenticateUser(string userName, string password);

        Task<User> GetUser(string userName);
    }
}

