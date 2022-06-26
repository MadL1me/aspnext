using Microsoft.EntityFrameworkCore;

namespace Asp.AwesomeTemplate.Data;

public sealed class Asp.AwesomeTemplateDbContext : DbContext
{
    public Asp.AwesomeTemplateDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}