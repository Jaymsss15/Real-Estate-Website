using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class RoleManagerController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public RoleManagerController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task<IActionResult> Index()
    {
        var roles = await _roleManager.Roles.ToListAsync();

        return View(roles);
    }
    [HttpPost]
    public async Task<IActionResult> AddRole(string roleName)
    {
        var existingRole = await _roleManager.FindByNameAsync(roleName);
        if (existingRole != null)
        {

            return RedirectToAction("Index");
        }

        var newRole = new IdentityRole(roleName);

        var result = await _roleManager.CreateAsync(newRole);

        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        else
        {

            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public async Task<IActionResult> DeleteRole(string roleName)
    {
        if (string.IsNullOrEmpty(roleName))
        {

            return RedirectToAction("Index");
        }

        var existingRole = await _roleManager.FindByNameAsync(roleName);

        if (existingRole == null)
        {
            return RedirectToAction("Index");
        }

        var result = await _roleManager.DeleteAsync(existingRole);

        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }


}


