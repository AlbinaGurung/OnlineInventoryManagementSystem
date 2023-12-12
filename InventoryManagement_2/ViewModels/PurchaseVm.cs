using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
namespace InventoryManagement_2.ViewModels;

public class PurchaseVm
{
 public int SuppliersId{get;set;}
 public List<Supplier> Suppliers;
 
 public DateOnly PurchaseDate{get;set;}
 public List<PurchaseItemVm> DetailsVm{get;set;}

}
