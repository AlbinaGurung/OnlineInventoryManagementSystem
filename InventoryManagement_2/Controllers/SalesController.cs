using Microsoft.AspNetCore.Mvc;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.Language;
namespace InventoryManagement_2.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            SalesSearchVm vm = new SalesSearchVm();
            vm.data = await _context.Sales.ToListAsync();
            return View(vm);
        }
        public async Task<IActionResult> Add()
        {
            SalesAddVm vm = new SalesAddVm();
            vm.Product = await _context.Units.Where(x=>x.Quantity>0).ToListAsync();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SalesAddVm vm)
        {
            try
            {
                if (vm == null)
                {
                    return BadRequest("Invalid request data");
                }
                else
                {
                    Sales sales = new Sales();
                    sales.CustomerName = vm.CustomerName;
                    sales.TotalAmount = 0;
                    sales.Transactions = vm.Transactions;
                    foreach (var detailvm in vm.DetailsVm)
                    {
                        var item = new SalesDetails();
                        item.ProductId = detailvm.ProductId;
                        item.Rate = detailvm.Rate;
                        item.Quantity = detailvm.Quantity;
                        item.Discount = detailvm.Discount;
                        item.TotalAmount = detailvm.Rate * detailvm.Quantity - detailvm.Discount;
                        item.Sales = sales;
                        sales.TotalAmount += item.TotalAmount;
                        sales.Details.Add(item);

                        var product = await _context.Units.Where
                    (x => x.Id == detailvm.ProductId).FirstOrDefaultAsync();

                        product.Quantity = product.Quantity - detailvm.Quantity;
                        _context.Units.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    _context.Sales.Add(sales);
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
}
