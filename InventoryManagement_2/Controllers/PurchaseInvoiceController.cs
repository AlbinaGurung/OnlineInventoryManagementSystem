using InventoryManagement_2.Data;
using InventoryManagement_2.Models;
using InventoryManagement_2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagement_2;

public class PurchaseInvoiceController
{
    ApplicationDbContext _context;
    public PurchaseInvoiceController(ApplicationDbContext context)
    {
        _context=context;
    }

}
