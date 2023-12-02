using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using InventoryManagement_2.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace InventoryManagement_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public void TestDBconnection()
        {
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings  ["Server=DESKTOP-B3HCI17\\SQLEXPRESS;Database=MeroDatabase;User Id=sa;Password=sa; TrustServerCertificate = true"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    ViewBag.Message = "Database connection is successful!";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}