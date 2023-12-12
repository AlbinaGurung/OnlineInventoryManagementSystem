using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace InventoryManagement_2.Controllers;
[Authorize(Roles = "Admin")]
public class SalesDetailsController : Controller
{
    public ApplicationDbContext _context;
    public SalesDetailsController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(int ID)
    {
         SalesDetailsSearchVm vm = new SalesDetailsSearchVm();
     
        
        vm.data=await _context.SalesDetails.Where(x=>x.Id==ID).Include(x => x.Product).ToListAsync();
        
        
        return View(vm);
    }
}
