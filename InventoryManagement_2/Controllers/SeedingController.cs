using System.Transactions;
using InventoryManagement_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement_2.Entity;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement_2.Controllers;

[AllowAnonymous]
public class SeedingController:Controller
{
public readonly ApplicationDbContext _context;
public SeedingController(ApplicationDbContext context)
{
    _context=context;
}
public async Task<IActionResult> SeedSuperAdmin()
{
    try
    {
        var previousSuperAdminExists=await _context.Users.AnyAsync(x => x.UserType == UserTypeConstants.Admin);
        if(!previousSuperAdminExists)
        {
            using var tx= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var Admin=new Users
            {
                Email = "super.admin",
                UserType = UserTypeConstants.Admin,
                 Name = "Super Admin",
                 PasswordHash=BCrypt.Net.BCrypt.HashPassword("admin")
                   
            };
            _context.Add(Admin);
            await _context.SaveChangesAsync();
            tx.Complete();
             return Content("Users data seeded");
        }
         return Content("Users data Already existed");
    }
    catch(Exception e)
    {
   return Content(e.Message);
    }

}
}
