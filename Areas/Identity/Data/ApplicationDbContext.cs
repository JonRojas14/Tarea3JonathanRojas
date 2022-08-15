using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaNo._3_Jonathan_Rojas_3101.Areas.Identity.Data;
using TareaNo._3_Jonathan_Rojas_3101.Models;

namespace TareaNo._3_Jonathan_Rojas_3101.Data;

public class ApplicationDbContext : IdentityDbContext<Usuarios>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Citas> Cita { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.Property(u => u.NombreCompleto).HasMaxLength(225);
        }
    }

}
