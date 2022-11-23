using System;
using ePizzaHub.Entities;

namespace ePizzaHub.WebUI.Interfaces
{
    public interface IUserAccessor
    {
        Task<User> GetUser();

    }
}

