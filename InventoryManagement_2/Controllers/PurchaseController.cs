using AspNetCoreHero.ToastNotification.Abstractions;
using InventoryManagement_2.Data;
using InventoryManagement_2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_2.Controllers;

public class PurchaseController:Controller
{
    private readonly ApplicationDbContext _context;
    private readonly INotyfService Notification;
    public PurchaseController(ApplicationDbContext context,INotyfService notyfService)
    {
        _context=context;
        Notification=notyfService;
    }
public async Task<IActionResult> Index(String? search=null)
{
    var Purchases=new PurchaseSearchVm();
    if(!string.IsNullOrEmpty(search))
    {
       
        try
        {
         Purchases.data=await _context.Purchases.Where(x=>x.Suppliers.Name.Contains(search)).ToListAsync();
         if(Purchases==null)
         {
            throw new Exception("No Purchases Found");
         }
         
        }
        catch(Exception e)
        {
         return RedirectToAction("Index");
        }
    }
    else
    {
        Purchases.data=await _context.Purchases.ToListAsync();
    }
    return View(Purchases);
    
}
public async Task<IActionResult> Edit()
{
    return View();
}
public async Task<IActionResult> Add()
{
    PurchaseAddVm vm=new PurchaseAddVm();
 vm.Categories = _context.Categories.ToList();
            vm.Unit = _context.Unit.ToList();
            vm.Product=_context.Units.ToList();
    return  View(vm);
}
}
