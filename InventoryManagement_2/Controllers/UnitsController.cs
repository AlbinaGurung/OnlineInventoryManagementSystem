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
    public async Task<IActionResult> Index(string? search = null)
    {
      var unit = new UnitSearchVm();
     if(!string.IsNullOrEmpty(search))
     {
      try

      {
        unit.data = await _context.Unit.Where(x=> x.Name.Contains(search)).ToListAsync();
      if(unit==null)
      {
        throw new Exception("Unit not Found");

      }
      
      }
      catch(Exception e)
      {
        return RedirectToAction("Index");
      }
     }
     else
     {
      unit.data= await _context.Unit.ToListAsync();
      
     }
      return View(unit);
 }
    public IActionResult Add()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(UnitAddVm vm)
    {
      try
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
      catch (Exception e)
      {
        return RedirectToAction("Index");
      }
    }
    

    public async Task<IActionResult> Edit(int id)
    {
      var y=await _context.Unit.Where(x => x.Id == id).FirstOrDefaultAsync();
      try
      {
      if(y==null) 
      {
      throw new Exception("Unit not found");
      }
      var vm= new UnitEditVm
      {
        Name=y.Name
      };
      return View(vm);
      }
      catch(Exception e)
      {
      return RedirectToAction("Index");
      }
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id,UnitEditVm vm)
    {
      
       var y= await _context.Unit.FirstOrDefaultAsync(x => x.Id == id);
      try
      {
      if(y==null)
      {
      throw new Exception("Unit not found");
      }
      
      using(var tx=new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
      {
      y.Name=vm.Name;
      //_context.Unit.Update(y);
      await _context.SaveChangesAsync();
      tx.Complete();
      notification.Success("Successfully Edited");
      return RedirectToAction("Index");
      }
      }
      catch(Exception e)
      {
      return RedirectToAction("Index");
      }

    }
    public async Task<IActionResult> Delete(int Id)
    {
      var unit=await _context.Unit.Where(x=>x.Id==Id).FirstOrDefaultAsync();
     try
     {
      if(unit==null)
      {
       throw new Exception("Unit not found");
      }
      using var tx=new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
      _context.Unit.Remove(unit);
      await _context.SaveChangesAsync();
      tx.Complete();
      notification.Success("Successfully Deleted");
      return RedirectToAction("Index");

     }
     catch(Exception e)
     {
      return RedirectToAction("Index");
     }
   }
}
}
