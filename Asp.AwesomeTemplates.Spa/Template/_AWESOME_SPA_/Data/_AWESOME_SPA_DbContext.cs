using Microsoft.EntityFrameworkCore;

namespace _AWESOME_SPA_.Data;

public sealed class _AWESOME_SPA_DbContext : DbContext
{
    public _AWESOME_SPA_DbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}