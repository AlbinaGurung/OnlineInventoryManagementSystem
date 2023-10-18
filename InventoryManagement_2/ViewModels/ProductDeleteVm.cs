using InventoryManagement_2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace InventoryManagement_2.ViewModels
{
    public class ProductDeleteVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
         public int Price { get; set; }
         public int UnitId{get;set;}
           [ValidateNever]
        public List<Units> Unit{get;set;}
        public int CategoryId {get; set;}
        [ValidateNever]
        public List<Category> Categories { get; set; }

       
    }
}
