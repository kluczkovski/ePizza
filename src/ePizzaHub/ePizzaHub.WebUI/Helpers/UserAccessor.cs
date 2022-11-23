using System;
using ePizzaHub.Entities;
using ePizzaHub.WebUI.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ePizzaHub.WebUI.Helpers
{
    public class UserAccessor : IUserAccessor
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetUser()
        {
            if (_httpContextAccessor.HttpContext?.User != null)
            {
                return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            }

            return null;
        }
   
    }
}

