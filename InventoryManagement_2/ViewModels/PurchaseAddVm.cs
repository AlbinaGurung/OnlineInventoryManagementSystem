
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagement_2.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagement_2.ViewModels;

public class PurchaseAddVm
{
     [Key]
    public int Id;
    public int ProductId{get;set;}
    [ForeignKey("ProductId")]
    public virtual List<Product2> Product{get;set;}
    public int SupplierId{get;set;}
    [ForeignKey("SupplierId")]
    public virtual List<Supplier> Supplier{get;set;}
   public DateOnly TransactionDate{get;set;}
   [ForeignKey ("TransactionDate")]
    public int PurchaseId{get;set;}
    [ForeignKey("PurchaseId")]
    public virtual Purchase Purchase{get;set;}
   
    public decimal Rate{get;set;}
    public decimal quantity{get;set;}
    public decimal TotalAmount{get;set;}
    public PurchaseDetails data{get;set;}
     
    
     public SelectList ProductsOptionsSelectList()
    {
        return new SelectList(
            Product, // List of items
            nameof(Product2.Id), // Which Property to use for Value 
            nameof(Product2.Name), // Which property to use for display
           ProductId // Selected value
        );
    }
     public SelectList SuppliersOptionsSelectList()
    {
        return new SelectList(
            Supplier, // List of items
            nameof(Models.Supplier.Id), // Which Property to use for Value 
            nameof(Models.Supplier.Name), // Which property to use for display
           SupplierId // Selected value
        );
    }
    
}
