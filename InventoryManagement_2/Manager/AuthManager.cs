using Microsoft.EntityFrameworkCore;
using InventoryManagement_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Linq.Expressions;
using InventoryManagement_2.Manager.Interfaces;
using System.Transactions;
using InventoryManagement_2.Entity;

namespace InventoryManagement_2.Manager;

public class AuthManager : IAuthManager
{
    public ApplicationDbContext _context;
    public IHttpContextAccessor _httpcontextaccessor;
    public AuthManager(ApplicationDbContext context, IHttpContextAccessor httpcontextaccessor)
    {
        _context = context;
        _httpcontextaccessor = httpcontextaccessor;
    }
    public async Task Login(String Username, String Password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == Username.ToLower().Trim());
        if (user == null)
        {
            throw new Exception("Invaild Username");
        }
        if (!BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
        {
            throw new Exception("Username and Password invalid");
        }
        var httpContext = _httpcontextaccessor.HttpContext;
        var claims = new List<Claim>
{
    new("Id",user.Id.ToString())
};
        var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

    }
    public async Task Logout()
    {
        await _httpcontextaccessor.HttpContext.SignOutAsync();
    }

    public async Task Register(String Username, String Password, String Email)
    {
        using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var User = new Users();
        User.Name = Username;
        User.Email = Email;
        User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);
        User.UserType = UserTypeConstants.NormalUser;
        User.UserStatus = UserStatusConstants.Active;
        User.CreatedDate = DateTime.Now;

        _context.Users.Add(User);
        await _context.SaveChangesAsync();
        tx.Complete();
    }
}
