using InventoryManagement_2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace InventoryManagement_2.ViewModels;
public class ProductEditVm
{
    public string? Name { get; set; }

    public int Price { get; set; }
    public int SalesPrice{get;set;}

    public List<Product>? data { get; set; }

    public int UnitId { get; set; }
    [ValidateNever]
    public List<Units> Unit { get; set; }
    public int CategoryId { get; set; }
    [ValidateNever]
    public List<Category> Categories { get; set; }

    public SelectList CategoryOptionSelectList()
    {
        return new SelectList(
            Categories, // List of items
            nameof(Category.Id), // Which Property to use for Value 
            nameof(Category.Name), // Which property to use for display
           CategoryId // Selected value
        );
    }
    public SelectList UnitsOptionsSelectList()
    {
        return new SelectList(
            Unit, // List of items
            nameof(Units.Id), // Which Property to use for Value 
            nameof(Units.Name), // Which property to use for display
           UnitId // Selected value
        );
    }
}