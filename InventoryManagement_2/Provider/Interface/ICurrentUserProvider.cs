using InventoryManagement_2.Entity;
namespace InventoryManagement_2.Provider.Interface;

public interface ICurrentUserProvider
{

    bool IsLoggedIn();
    Task<Users?> GetCurrentUser();
    long? GetCurrentUserId();
}
