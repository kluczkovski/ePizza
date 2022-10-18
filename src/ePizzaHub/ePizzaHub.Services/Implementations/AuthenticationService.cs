using System;
using ePizzaHub.Entities;
using ePizzaHub.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ePizzaHub.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService 
    {
        protected SignInManager<User> _signManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;

        public AuthenticationService(SignInManager<User> signInManager,
            UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User> AuthenticateUser(string userName, string password)
        {
            var result = await _signManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);
                var roles = await _userManager.GetRolesAsync(user);
                user.Roles = roles.ToArray();

                return user;
            }

            return null;
        }

        public async Task<bool> CreateUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                //Adim, User
                string role = "Admin";
                var identityResult = await _userManager.AddToRoleAsync(user, role);
                if (identityResult.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<User> GetUser(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signManager.SignOutAsync();
                return true;

            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}

