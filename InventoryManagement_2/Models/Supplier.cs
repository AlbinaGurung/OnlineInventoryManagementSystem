using System.ComponentModel.DataAnnotations;

namespace InventoryManagement_2.Models;

public class Supplier
{
[Key]
public int Id{get;set;}
public string? Name{get;set;}
public string? Address{get;set;}
}
