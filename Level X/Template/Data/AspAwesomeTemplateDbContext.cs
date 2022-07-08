using Microsoft.EntityFrameworkCore;

namespace AspAwesomeTemplate.Data;

public sealed class AspAwesomeTemplateDbContext : DbContext
{
    public AspAwesomeTemplateDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}