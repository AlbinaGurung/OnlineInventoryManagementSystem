using InventoryManagement_2.Models;

namespace InventoryManagement_2.ViewModels;

public class PurchaseDetailsSearchVm
{
public string? search{get;set;}
public List<PurchaseDetails> data;
public int PurchaseId{get;set;}
}
