using Microsoft.AspNetCore.Mvc;
using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
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

            var product = _context.Units.FirstOrDefault();
           

            var sale = new Sales();
            sale.CustomerName="Albina";
            sale.Transactions=DateTime.Now;
            sale.TotalAmount=450;


            var SalesDetails = new SalesDetails
            {
                Product=product,
                quantity=4,
                Rate=50,
                NetAmount=200,
                discount=5
            };

            sale.Details.Add(SalesDetails);
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return Content("Content Added");
        }
    }
}
