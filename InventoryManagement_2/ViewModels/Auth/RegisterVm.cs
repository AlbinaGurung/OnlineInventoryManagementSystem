using InventoryManagement_2.Entity;
namespace InventoryManagement_2.ViewModels.Auth;


public class RegisterVm
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  
        public string ErrorMessage;
}
