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

        #if (identity)
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<IdentityRole>().ToTable("Role");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
        #endif
    }
}