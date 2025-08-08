using EmployeeTrackingApp.Entity;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public AppDbContext() // ✅ TEMP FIX for manual use in console
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) // ✅ Prevent double config when injected
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EmployeeDb100;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
