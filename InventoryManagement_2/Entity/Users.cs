﻿﻿using System.ComponentModel.DataAnnotations.Schema;
//using SimpleAuth.Constants;
namespace InventoryManagement_2.Entity
{
    
[Table("auth_user")]
public class Users
{
    
 public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string UserStatus { get; set; } = UserStatusConstants.Active;

    public string UserType { get; set; } = UserTypeConstants.NormalUser;

  public DateTime CreatedDate { get; set; } = DateTime.Now;

}
}

