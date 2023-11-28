
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagement_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement_2.ViewModels;

public class PurchaseAddVm
{
     [Key]
    public int Id{get;set;}
    public int ProductId{get;set;}
    [ForeignKey("ProductId")]
    public virtual List<Product2> Product{get;set;}
    
    public int CategoryId{get;set;}

    [ForeignKey("CategoryId")]
    public virtual List<Category> Categories 
    public int UnitId{get;set;}
    [ForeignKey("UnitId")]
    public virtual List <Units> Unit{get;set;} 
     public int SupplierId{get;set;}
    [ForeignKey("SupplierId")]
   public DateTime TransactionDate{get;set;}
   [ForeignKey ("TransactionDate")]
    public int PurchaseId{get;set;}
    [ForeignKey("PurchaseId")]
    public virtual Purchase Purchase{get;set;}
   
    public decimal Rate{get;set;}
    public decimal quantity{get;set;}
    public decimal TotalAmount{get;set;}
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
     public SelectList ProductsOptionsSelectList()
    {
        return new SelectList(
            Product, // List of items
            nameof(Product2.Id), // Which Property to use for Value 
            nameof(Product2.Name), // Which property to use for display
           ProductId // Selected value
        );
    }
}
