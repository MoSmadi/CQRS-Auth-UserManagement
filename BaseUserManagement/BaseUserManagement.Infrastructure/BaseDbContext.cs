using BaseUserManagement.Infrastructure.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseUserManagement.Infrastructure;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }
    
    internal virtual DbSet<UserDb> User { get; set; }
}