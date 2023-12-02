using System.ComponentModel.DataAnnotations;
using System;
namespace InventoryManagement_2.Models;

public class Units
{
[Key]
public int Id{get;set;}
public string? Name{get; set;}
}
