using AspNetCoreHero.ToastNotification.Abstractions;
using InventoryManagement_2.Data;
using InventoryManagement_2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_2.Controllers;

public class PurchaseDetailsController:Controller
{
    private readonly ApplicationDbContext _context;
    private readonly INotyfService Notification;
    public PurchaseDetailsController(ApplicationDbContext context,INotyfService notyfService)
    {
        _context=context;
        Notification=notyfService;
    }
public async Task<IActionResult> Index(int id)
{
    
   var vm=new PurchaseDetailsSearchVm();
   vm.data=await _context.PurchaseDetails.Where(x=>x.PurchaseId==id).Include(x=>x.Unit).Include(x=>x.Category).ToListAsync();
    return View(vm);
}
public IActionResult Edit()
{
    return View(); 
}
}
