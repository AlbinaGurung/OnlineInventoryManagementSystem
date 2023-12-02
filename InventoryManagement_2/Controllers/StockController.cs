using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_2.Controllers;

public class StockController : Controller
{
public IActionResult Index()
{
    return View();
}
}
