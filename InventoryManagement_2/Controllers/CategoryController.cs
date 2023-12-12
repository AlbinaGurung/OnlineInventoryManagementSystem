using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
namespace InventoryManagement_2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService Notification;
        public CategoryController(ApplicationDbContext context, INotyfService notifyservice)
        {
            _context = context;
            Notification = notifyservice;
        }
        public async Task<IActionResult> IndexAsync(String? search = null)
        {
            var cat = new CategorySearchVm();

            if (!string.IsNullOrEmpty(search))
            {
                try
                {
                    cat.data = await _context.Categories.Where(x => x.Name.Contains(search)).ToListAsync();
                    if (cat == null)
                    {
                        throw new Exception("Category not found");
                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }
            else
                {
                    cat.data = _context.Categories.ToList();
                }
            return View(cat);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddVm vm)
        {
            var cat = new Category();
            using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                cat.Name = vm.Name;
                _context.Categories.Add(cat);
                await _context.SaveChangesAsync();
                tx.Complete();
                return RedirectToAction("Add");
            }
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var cat = await _context.Categories.Where(x => x.Id == Id).FirstOrDefaultAsync();
            try
            {
                if (cat == null)
                {
                    throw new Exception("Category Not Found");
                }
                var vm = new CategoryEditVm
                {
                    Name = cat.Name
                };
                return View(vm);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryEditVm vm)
        {
            var cat = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                cat.Name = vm.Name;
                _context.Categories.Update(cat);
                await _context.SaveChangesAsync();
                tx.Complete();
                Notification.Success("Successfully Updated");
                return RedirectToAction("Index");
            }
        }
        // [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (cat == null)
                {
                    throw new Exception("Item not found");
                }

                using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                _context.Categories.Remove(cat);
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



