using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement_2.Models;

public class PurchaseDetails
{
    [Key]
    public int Id{get;set;}
    public int ProductId{get;set;}
    public virtual Product2 Product{get;set;}
    
    public int CategoryId{get;set;}

    [ForeignKey("CategoryId")]
    public virtual Category Category {get;set;}
    public int UnitId{get;set;}
    [ForeignKey("UnitId")]
    public virtual Units Unit{get;set;} 
    public int PurchaseId{get;set;}
    [ForeignKey("PurchaseId")]
    public virtual Purchase Purchase{get;set;}
    public decimal Rate{get;set;}
    public decimal quantity{get;set;}
    public decimal TotalAmount{get;set;}




}
