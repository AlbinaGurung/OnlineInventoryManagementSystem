﻿using System.Security.Claims;
using InventoryManagement_2.Data;
using InventoryManagement_2.Entity;
using InventoryManagement_2.Provider.Interface;

namespace InventoryManagement_2.Provider;

public class CurrentUserProvider : ICurrentUserProvider
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ApplicationDbContext _context;

    public CurrentUserProvider(IHttpContextAccessor contextAccessor, ApplicationDbContext context)
    {
        _contextAccessor = contextAccessor;
        _context = context;
    }

    public bool IsLoggedIn()
        => GetCurrentUserId() != null;

    public async Task<Users?> GetCurrentUser()
    {
        var currentUserId = GetCurrentUserId();
        if (!currentUserId.HasValue) return null;

        return await _context.Users.FindAsync(currentUserId.Value);
    }

    public long? GetCurrentUserId()
    {
        var userId = _contextAccessor.HttpContext?.User.FindFirstValue("Id");
        if (string.IsNullOrWhiteSpace(userId)) return null;
        return Convert.ToInt64(userId);
    }

    // Task<Users?> ICurrentUserProvider.GetCurrentUser()
    // {
    //     throw new NotImplementedException();
    // }
}