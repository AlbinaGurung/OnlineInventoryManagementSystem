using System.ComponentModel.DataAnnotations;

namespace InventoryManagement_2.Models;

public class Stock
{
    [Key]
public int Id{get;set;}
public string Name{get;set;}

public int Quantity{get;set;}
public int UnitId{get;set;}
public virtual Units Unit{get;set;}

public int CategoryId{get;set;}
public virtual Category Category{get;set;}

}
