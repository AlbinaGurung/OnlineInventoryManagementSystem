using InventoryManagement_2.Models;

namespace InventoryManagement_2.ViewModels;
public class ProductEditVm
{
   public string? Name { get; set; }

    public int Price { get; set; }
    public List<Product>? data { get; set;}
}