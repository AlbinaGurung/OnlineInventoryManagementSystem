using InventoryManagement_2.Models;
namespace InventoryManagement_2.ViewModels
{
    public class ProductSearchVm
    {
        public string? Name { get; set; }
        public List<Product2>? data { get; set; }

     public List<ProductDisplayVm> DisplayData;
    }
}
