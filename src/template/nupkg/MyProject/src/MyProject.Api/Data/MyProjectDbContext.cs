using Microsoft.EntityFrameworkCore;

namespace MyProject.Data;

public sealed class MyProjectDbContext : DbContext
{
    public MyProjectDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}