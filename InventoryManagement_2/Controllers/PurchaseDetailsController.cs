using AspNetCoreHero.ToastNotification.Abstractions;
using InventoryManagement_2.Data;
using InventoryManagement_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_2.Controllers;
[Authorize(Roles = "Admin")]
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
   vm.PurchaseId=id;
   vm.data=await _context.PurchaseDetails.Where(x=>x.PurchaseId==id).Include(x=>x.Product).ToListAsync();
    return View(vm);
}
public IActionResult Edit()
{
    return View(); 
}
public async Task<IActionResult> Invoice(int Id)
{
    var vm=new PurchaseInvoiceVm();
    var purchase=await _context.Purchases.Where(x=>x.Id==Id).Include(x=>x.Suppliers).FirstOrDefaultAsync();
vm.purchasedetails=await _context.PurchaseDetails.Where(x=>x.PurchaseId==Id).Include(x=>x.Product).ToListAsync();
vm.SupplierName=purchase.Suppliers.Name;
vm.TransactionDate=purchase.PurchaseDate;
vm.Address=purchase.Suppliers.Address;


return View(vm);

}
}
