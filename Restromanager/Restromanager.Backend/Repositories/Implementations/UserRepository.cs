﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class UserRepository (DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager) : IUserRepository
    {
        private readonly DataContext _context = context;
        private readonly UserManager<User> _userManager=userManager;
        private readonly RoleManager<IdentityRole> _roleManager=roleManager;
        private readonly SignInManager<User> _signInManager = signInManager;

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }
        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user,password);
        }

        public Task AddUserToRoleAsync(User user, string roleName)
        {
            return _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user,currentPassword, newPassword);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists= await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name=roleName });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            var user= await _context.Users
                .Include(u=>u.City!)
                .ThenInclude(c=>c.State!)
                .ThenInclude(s=>s.Country)
                .FirstOrDefaultAsync(x=>x.Email==email);
            return user!;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.City!)
                .ThenInclude(c => c.State!)
                .ThenInclude(s => s.Country)
                .FirstOrDefaultAsync(x => x.Id == userId.ToString());
            return user!;

        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }
    }
}
