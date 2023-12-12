using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement_2.Models
{
    [Table("inv_salesDetails")]
    public class SalesDetails
    {
        [Key]
        public long Id { get; set; }
        public long Quantity { get; set; }

        public decimal Rate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }


      
        public long  SalesId { get; set; }
        public virtual Sales Sales { get; set; }

        public int ProductId { get; set; }
        public virtual Product2 Product { get; set; }

    }
}
