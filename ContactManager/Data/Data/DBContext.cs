using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
       : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
        .Property(c => c.Salary)
        .HasColumnType("decimal(18,2)");
    }
}
