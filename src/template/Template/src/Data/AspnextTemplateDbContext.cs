using Microsoft.EntityFrameworkCore;

namespace AspnextTemplate.Data;

public sealed class AspnextTemplateDbContext : DbContext
{
    public AspnextTemplateDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}