using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement_2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService Notification;
        public ProductController(ApplicationDbContext context, INotyfService notifyService)
        {
            _context = context;
            Notification = notifyService;
        }
        public async Task<IActionResult> Index(string? search = null)
        {
            var products = new ProductSearchVm();

            if (!String.IsNullOrEmpty(search))
            {
                products.data = await _context.Units.Where(x => x.Name.Contains(search)).Include(x => x.Category).Include(x => x.Unit).ToListAsync();

            }
            else
            {
                products.data = await _context.Units.Include(x => x.Category).Include(x => x.Unit).ToListAsync();
            }
            return View(products);
        }
        public IActionResult Add()

        {
            var vm = new ProductAddVm();
            vm.Categories = _context.Categories.ToList();
            vm.Unit = _context.Unit.ToList();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddVm vm)
        {
            if (vm is null)
            {
                throw new ArgumentNullException(nameof(vm));
            }

            try
            {
                Product2 item = new()
                {
                    Id = vm.Id,
                    Price = vm.Price,
                    SalesPrice = vm.SalesPrice,
                    Name = vm.Name,
                    Quantity = 0,
                    CategoryId = vm.CategoryId,
                    UnitId = vm.UnitId
                };
                _context.Units.Add(item);
                await _context.SaveChangesAsync();
                Notification.Success("Successfully Added");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            //searching for the item in databse whose id is equal to the id passed from the page
            var item = await _context.Units.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (item == null)
                {
                    throw new Exception("Item Not Found");
                }
                //giving that found item to the view model to display it to the page
                var vm = new ProductEditVm()
                {
                    Name = item.Name,
                    Price = item.Price,
                    SalesPrice = item.SalesPrice,
                    CategoryId = item.CategoryId,
                    UnitId = item.UnitId
                };
                vm.Categories = await _context.Categories.ToListAsync();
                vm.Unit = await _context.Unit.ToListAsync();
                return View(vm);
            }
            catch (Exception)
            {
                RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditVm vm)
        {
            var item = _context.Units.FirstOrDefault(x => x.Id == id);

            try
            {
                if (item == null)
                {
                    throw new Exception("Item Not Found");
                }
                item.Name = vm.Name;
                item.Price = vm.Price;
                item.SalesPrice = vm.SalesPrice;
                item.UnitId = vm.UnitId;
                item.Quantity = item.Quantity;
                item.CategoryId = vm.CategoryId;

                _context.Units.Update(item);
                await _context.SaveChangesAsync();
                Notification.Success("Successfully Edited");
                return RedirectToAction("Index");

            }

            catch (Exception e)
            {
                RedirectToAction("Index" + e);
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Units.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (item == null)
                {
                    throw new Exception("Item not found");
                }

                using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                _context.Units.Remove(item);
                await _context.SaveChangesAsync();
                tx.Complete();
                Notification.Success("Successfully Deleted");

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
