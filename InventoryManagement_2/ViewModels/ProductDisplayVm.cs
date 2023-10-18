using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using InventoryManagement_2.Models;
namespace InventoryManagement_2.ViewModels;
public class ProductDisplayVm
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitId{get;set;}
    public List<Units> Unit { get; set; }
    public int CategoryId { get; set; }
    [ValidateNever]
    public List<Category> Categories { get; set; }

    public List<ProductDisplayVm> DisplayData;
}
