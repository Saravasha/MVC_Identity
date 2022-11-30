using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using MVC_Identity.Models;
using MVC_Identity.ViewModels;

namespace MVC_Identity.Controllers
{

    public class RoleController : Controller
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<ApplicationUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            role.NormalizedName = role.Name.ToUpper();
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");

            
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var userToDelete = await _userManager.FindByIdAsync(id);

            if (userToDelete != null)
            {
                await _userManager.DeleteAsync(userToDelete);
            }
            return RedirectToAction("ShowAllUsers");
        }

        public IActionResult AddUserToRole()
        {
            ViewBag.Users = new SelectList(_userManager.Users, "Id", "UserName");
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, roleName);
            return RedirectToAction("Index");
        }

        public IActionResult ShowAllUsers()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> ShowUserRoles(string Id)
        {
            UserRoleViewModel vm = new UserRoleViewModel();
            var user = await _userManager.FindByIdAsync(Id);

            var assignedRoles = new List<string>(await _userManager.GetRolesAsync(user));
            vm.UserId = Id;
            vm.UserName = $"{user.FirstName} {user.LastName}";
            vm.Roles.AddRange(assignedRoles);
            
            return View(vm);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRoleFromUser(string rolename, string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            await _userManager.RemoveFromRoleAsync(user, rolename);

            return RedirectToAction("ShowUserRoles", new { id = userid });
        }

    }
}
