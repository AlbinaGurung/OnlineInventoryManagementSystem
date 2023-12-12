using InventoryManagement_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement_2.ViewModels;

public class SalesAddVm
{

    public String CustomerName { get; set; }

    public DateTime Transactions { get; set; }
    public List<Product2> Product;


    public List<SalesDetailsVm> DetailsVm { get; set; }
    public SelectList ProductsOptionsSelectList()
    {
        return new SelectList(
            Product, // List of items
            nameof(Product2.Id), // Which Property to use for Value 
            nameof(Product2.Name) // Which property to use for display

        );
    }
}
public class SalesDetailsVm
{
    public long Quantity { get; set; }

    public decimal Rate { get; set; }

    public decimal Discount { get; set; }

    public int ProductId { get; set; }

}