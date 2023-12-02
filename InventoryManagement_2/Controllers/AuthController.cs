using InventoryManagement_2.Data;
using InventoryManagement_2.Manager;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;
using InventoryManagement_2.Entity;
using InventoryManagement_2.Manager.Interfaces;
using InventoryManagement_2.ViewModels;
using InventoryManagement_2.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
namespace InventoryManagement_2.Controllers;


[AllowAnonymous]
public class AuthController : Controller
{
    private readonly INotyfService notification;
    private readonly IAuthManager _authManager;
    private readonly ApplicationDbContext _context;
    public AuthController(IAuthManager authManger, ApplicationDbContext context,INotyfService notifyService)
    {
        _authManager = authManger;
        _context = context;
        notification= notifyService;
    }

    public IActionResult Login()
    {
        var vm = new LoginVm();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        try
        {
            await _authManager.Login(vm.Username, vm.Password);
           notification.Success("Successfully Loggedin");
            return RedirectToAction("Index", "Product");
        }
        catch (Exception e)
        {
            vm.ErrorMessage = e.Message;
            return View(vm);
        }

    }
    public async Task<IActionResult> Logout()
    {
        await _authManager.Logout();
        return RedirectToAction("Login");
    }


    public IActionResult Register()
    {
        var vm = new RegisterVm();
        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVm vm)
    {

        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        try
        {
            await _authManager.Register(vm.UserName, vm.Password, vm.Email);
            return RedirectToAction("Login");

        }
        catch (Exception e)
        {
            vm.ErrorMessage = e.Message;
            return View(vm);
        }

    }
}
