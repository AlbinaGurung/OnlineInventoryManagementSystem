using InventoryManagement_2.Models;
namespace InventoryManagement_2.ViewModels;

public class PurchaseInvoiceVm
{
   
    public String SupplierName{get;set;}
   public List<PurchaseDetails> purchasedetails{get;set;}
    public DateOnly TransactionDate { get; set; }
    public string Address{get;set;}


}
