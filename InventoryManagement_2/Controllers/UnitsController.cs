using InventoryManagement_2.ViewModels;
using InventoryManagement_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using InventoryManagement_2.Models;
using System.Transactions;
using AspNetCoreHero.ToastNotification.Abstractions;


namespace InventoryManagement_2.Controllers
{

  public class UnitsController : Controller
  {
    private readonly ApplicationDbContext _context;
    private readonly INotyfService notification;
    public UnitsController(ApplicationDbContext context, INotyfService notifyService)
    {
      _context = context;
      notification = notifyService;
    }
    public IActionResult Index()
    {
      return View();


    }
    public IActionResult Add()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(UnitAddVm vm)
    {
      var unit = new Units();


      using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
      {
        unit.Name = vm.Name;
        _context.Unit.Add(unit);
        await _context.SaveChangesAsync();
        tx.Complete();
        notification.Success("Successfully Added");
        return RedirectToAction("Add");
      }
    }
  }
}
