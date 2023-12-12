       using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement_2.Models
{
    [Table("inv_sales")]
    public class Sales
    {
        [Key]
        public long Id { get; set; }
        public DateTime Transactions { get; set; }

        public String? CustomerName { get; set; }

        public decimal TotalAmount { get; set; }
        
        public virtual List<SalesDetails> Details { get; set; }= new List<SalesDetails>();
    }
}
