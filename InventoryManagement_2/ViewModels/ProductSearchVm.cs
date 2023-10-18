using InventoryManagement_2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace InventoryManagement_2.ViewModels
{
    public class ProductSearchVm
    {
        public string? Name { get; set; }

        public List<Product2>? data;
    }

}

