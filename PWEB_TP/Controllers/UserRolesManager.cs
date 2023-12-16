using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWEB_TP.Models;
using PWEB_TP.ViewModels;
using TP_PWEB.Data;

public class UserRolesManagerController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public UserRolesManagerController(UserManager<ApplicationUser> userManager,
   RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var userRolesViewModelList = new List<UserRolesViewModel>();

        foreach (var user in users)
        {
            var roles = await GetUserRoles(user);

            var userRolesViewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                PrimeiroNome = user.PrimeiroNome,
                UltimoNome = user.UltimoNome,
                UserName = user.UserName,
                Roles = roles
            };

            userRolesViewModelList.Add(userRolesViewModel);
        }

        return View(userRolesViewModelList);
    }

    private async Task<List<string>> GetUserRoles(ApplicationUser user)
    {
        return new List<string>(await _userManager.GetRolesAsync(user));
    }

    public async Task<IActionResult> Details(string userId)
    {
        if (userId == null || _userManager.Users == null)
            return NotFound();

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var roles = await GetUserRoles(user);
        var allRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

        var model = new UserRolesViewModel
        {
            UserId = user.Id,
            PrimeiroNome = user.PrimeiroNome,
            UltimoNome = user.UltimoNome,
            UserName = user.UserName,
            Roles = roles,
            AvailableRoles = allRoles
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Details(UserRolesViewModel model)
    {
        if (model == null || string.IsNullOrEmpty(model.UserId))
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(model.UserId);

        if (user == null)
        {
            return NotFound();
        }

        // Retrieve the selected roles from the form
        var selectedRoles = Request.Form["selectedRoles"].ToList();

        // Get the user's current roles
        var existingRoles = await _userManager.GetRolesAsync(user);

        // Add the new roles
        var rolesToAdd = selectedRoles.Except(existingRoles);
        await _userManager.AddToRolesAsync(user, rolesToAdd);

        // Remove the old roles
        var rolesToRemove = existingRoles.Except(selectedRoles);
        await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult CriaUtilizador()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriaUtilizador(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PrimeiroNome = model.PrimeiroNome,
                UltimoNome = model.UltimoNome,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                // Adicionar o usuário à role especificada
                await _userManager.AddToRoleAsync(user, model.Role);

                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }


    public async Task<IActionResult> Delete(string userId)
    {
        if (userId == null)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmarDelete(string userId)
    {
        if (userId == null)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        else
        {
            // Lida com erros de exclusão, se necessário
            ModelState.AddModelError(string.Empty, "Failed to delete user");
            return View("Index");
        }
    }
}
