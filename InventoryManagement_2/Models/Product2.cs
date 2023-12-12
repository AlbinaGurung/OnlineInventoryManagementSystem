using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using InventoryManagement_2.Models;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement_2.Models
{
    [Table("in_prod")]
    public class Product2
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int SalesPrice{get;set;}
        public decimal Quantity{get;set;}
        public int UnitId { get; set; }
        public virtual Units Unit { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
