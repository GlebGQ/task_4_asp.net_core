using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using task_4_asp.Models;
using task_4_asp.ViewModels;

namespace task_4_asp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = userManager.Users;

            List<UserViewModel> dtos = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                LastLoginDate = u.LastLoginDate,
                RegistrationDate = u.RegistrationDate,
                IsBlocked = u.IsBlocked
            }).ToList();

            return View(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUsers(IEnumerable<string> userIds)
        {
            foreach (var id in userIds)
            {

                var foundUser = await userManager.FindByIdAsync(id);
                await userManager.DeleteAsync(foundUser);

            }

            if (userIds.Contains(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("GetAllUsers", "User");
        }

        [HttpPost]
        public async Task<IActionResult> BlockUsers(IEnumerable<string> userIds)
        {
            foreach (var id in userIds)
            {

                var foundUser = await userManager.FindByIdAsync(id);
                foundUser.IsBlocked = true;
                await userManager.UpdateAsync(foundUser);

            }

            if (userIds.Contains(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("GetAllUsers", "User");
        }

        [HttpPost]
        public async Task<IActionResult> UnBlockUsers(IEnumerable<string> userIds)
        {
            foreach (var id in userIds)
            {

                var foundUser = await userManager.FindByIdAsync(id);
                foundUser.IsBlocked = false;
                await userManager.UpdateAsync(foundUser);

            }

            return RedirectToAction("GetAllUsers", "User");
        }
    }
}