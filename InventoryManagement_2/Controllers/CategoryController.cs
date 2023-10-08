using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
namespace InventoryManagement_2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(CategorySearchVm vm)
        {
            vm.Categories=_context.Categories.ToList();
            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

         public async Task<IActionResult> Add(CategoryAddVm vm)
          {
             var cat=new Category();
            using (var tx=new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
           {
           cat.Name=vm.Name;
            _context.Categories.Add(cat);
           await  _context.SaveChangesAsync();
            tx.Complete();
            return RedirectToAction("Add");
           }
         }
   
 

    }
}
   /*public async Task<IActionResult> Add(CategoryAddVm vm)
  {
   var cat=new Category();
   using (var tx=new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
   {
   cat.Name=vm.Name;
  _context.Categories.Add(cat);
  await  _context.SaveChangesAsync();
  tx.Complete();
   return RedirectToAction("Add");
   }
   }
   
  public IActionResult Index(CategorySearchVm vm)
   {
    //vm.Categories=_context.Categories.Where(x=>string.IsNullOrEmpty(vm.Name) || x.Name.Contains(vm.Name)).ToListAsync();
   return View(vm);    
   }
  */



