using InventoryManagement_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_2;

public class ProductrateController : Controller
{
    ApplicationDbContext _context;
    public ProductrateController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> rate(int productid)
    {
        var product = await _context.Units.Where(x => x.Id == productid).FirstOrDefaultAsync();
        if (product != null)
        {
            return Json(new
            {
                purchaseRate = product.Price,
                salesRate = product.SalesPrice
            });
        }
        else
        {
            // If the product is not found, return a JSON response with an appropriate message or handle it accordingly
            return Json(new
            {
                error = "Product not found"
            });
        }

    }
}
