using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;

namespace InventoryManagement_2.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

      

        public async Task<IActionResult> Index(string? search = null)
        {
            var products = new ProductSearchVm();
          
            if (!String.IsNullOrEmpty(search))
            {
                products.data= await _context.Units.Where(x => x.Name.Contains(search)).Include(x=>x.Category).ToListAsync();
                products.DisplayData=await _context.Units.Where(x=>string.IsNullOrEmpty(search) || x.Name.Contains(search))
                .Select(x=>new ProductDisplayVm()
                {
                    Id=x.Id,
                    Name=x.Name
                }).ToListAsync();
             }
            else
            {
                products.data = await _context.Units.ToListAsync();
            }
            return View(products);


         
        }
        public  IActionResult Add()

        {

            var vm = new ProductAddVm();
            vm.Categories = _context.Categories.ToList();
            return View(vm);  
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddVm vm)
        {

           
            try
            {
             
                    Product2 item = new()
                    {
                        
                        Price=vm.Price,
                        Name=vm.Name,
                        CategoryId=vm.CategoryId,
                        UnitId=vm.UnitId
                    };

                    _context.Units?.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
               
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }



        }
        
        public IActionResult Edit(int id)
        {
            //searching for the item in databse whose id is equal to the id passed from the page
            var item=_context.Units.Where(x => x.Id == id).FirstOrDefault();
            try 
            {
                if (item==null)
                {
                    throw new Exception("Item Not Found");
                }
                //giving that found item to the view model to display it to the page
                var vm = new ProductEditVm() { Name=item.Name ,Price=item.Price};
                
                
                return View(vm);
            }
            catch (Exception )
            {
                RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditVm vm)
        {
            var item= _context.Units.FirstOrDefault(x => x.Id==id);
           
            try
            {
                if (item==null)
                {
                    throw new Exception("Item Not Found");
                }


                item.Name=vm.Name;
                item.Price=vm.Price;

                _context.Units.Update(item);
                await _context.SaveChangesAsync();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
                
            }

            catch (Exception e)
            {
                RedirectToAction("Index"+e);
            }
                return View();
        }

       

        
        public async Task<IActionResult> Delete(int id)
        {
            var item = _context.Units.Where(x => x.Id==id).FirstOrDefault();
            try
            {
                if (item==null)
                {
                    throw new Exception("Item not found");
                }

                using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    _context.Units.Remove(item);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Product DELETED successfully";
                    return RedirectToAction("Index");
                    tx.Complete();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }



        }






    }
}
