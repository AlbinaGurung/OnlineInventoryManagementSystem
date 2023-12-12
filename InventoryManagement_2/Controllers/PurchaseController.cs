using AspNetCoreHero.ToastNotification.Abstractions;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model.Map;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_2.Controllers;
[Authorize(Roles = "Admin")]
public class PurchaseController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly INotyfService Notification;
    public PurchaseController(ApplicationDbContext context, INotyfService notyfService)
    {
        _context = context;
        Notification = notyfService;
    }
    public async Task<IActionResult> Index(String? search = null)
    {
        var Purchases = new PurchaseSearchVm();
        if (!string.IsNullOrEmpty(search))
        {

            try
            {
                Purchases.data = await _context.Purchases.Where(x => x.Suppliers.Name.Contains(search)).Include(x => x.Suppliers).ToListAsync();
                if (Purchases == null)
                {
                    throw new Exception("No Purchases Found");
                }

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
        else
        {
            Purchases.data = await _context.Purchases.Include(x => x.Suppliers).ToListAsync();
        }
        return View(Purchases);

    }
    public async Task<IActionResult> Edit()
    {
        return View();
    }
    public async Task<IActionResult> Add()
    {
        PurchaseAddVm vm = new PurchaseAddVm();


        vm.Supplier = _context.Suppliers.ToList();

        vm.Product = _context.Units.ToList();
        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PurchaseVm vm)
    {

        try
        {
            if (vm == null)
            {
                return BadRequest("Invalid request data");
            }
            else
            {
                var purchase = new Purchase();
                purchase.SuppliersId = vm.SuppliersId;
                purchase.PurchaseDate = vm.PurchaseDate;


                foreach (var detailVm in vm.DetailsVm)
                {
                    var item = new PurchaseDetails();
                    item.ProductId = detailVm.ProductId;
                    item.Rate = detailVm.Rate;
                    item.quantity = detailVm.Quantity;
                    item.Discount = detailVm.Discount;
                    item.TotalAmount = detailVm.Rate * detailVm.Quantity - detailVm.Discount;
                    item.Purchase = purchase;
                    purchase.TotalAmount += item.TotalAmount;
                    purchase.PurchaseDetails.Add(item);



                    var product = await _context.Units.Where
                    (x=> x.Id == detailVm.ProductId).FirstOrDefaultAsync();
                    
                    product.Quantity = product.Quantity+detailVm.Quantity;
                    _context.Units.Update(product);
                    await _context.SaveChangesAsync();

                }

                _context.Purchases.Add(purchase);
                await _context.SaveChangesAsync();
                return Json(new
                {
                    success = true
                });
            }
        }
        catch (Exception e)
        {
            return Json(new
            {
                success = false,
                Message = e.Message
            });
        }

    }

}
