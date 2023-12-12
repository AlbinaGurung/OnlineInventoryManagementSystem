using AspNetCoreHero.ToastNotification.Abstractions;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_2;
[Authorize(Roles = "Admin")]
public class SupplierController : Controller
{
    public ApplicationDbContext _context;
    private readonly INotyfService Notification;
    public SupplierController(ApplicationDbContext context, INotyfService notifyService)
    {
        Notification = notifyService;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        SupplierDisplayVm vm = new SupplierDisplayVm();
        vm.data = await _context.Suppliers.ToListAsync();
        return View(vm);
    }

   public IActionResult Add()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(SupplierAddVm vm)

    {
        try
        {
            Supplier s = new Supplier();
            s.Name = vm.Name;
            s.Address = vm.Address;
            _context.Suppliers.Add(s);
            await _context.SaveChangesAsync();
            Notification.Success("Successfully Added");
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index");
        }

    }

}
