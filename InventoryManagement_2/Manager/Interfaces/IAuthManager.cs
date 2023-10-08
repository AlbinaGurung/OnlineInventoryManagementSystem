namespace InventoryManagement_2.Manager.Interfaces;

public interface IAuthManager
{
 Task Login(string Username,string Password);
 Task Logout();
 Task Register(String UserName,String Password,String Email);
}
