using System.ComponentModel.DataAnnotations;

namespace InventoryManagement_2.Models;

public class Purchase
{
    [Key]
    public int Id { get; set; }
    public int SuppliersId { get; set; }
    public virtual Supplier Suppliers { get; set; }
    public DateOnly PurchaseDate { get; set; }
    public decimal TotalAmount { get; set; }
    
    public virtual List<PurchaseDetails> PurchaseDetails { get; set; } = new List<PurchaseDetails>();
}
