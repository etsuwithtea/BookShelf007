using Microsoft.EntityFrameworkCore;
using BookShelf007.Models;
using System.Text.RegularExpressions;

namespace BookShelf007.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("books");
            entity.Property(b => b.Id).HasColumnName("id").UseIdentityByDefaultColumn();
        });

        // Convert all column names to snake_case and handle DateTime UTC conversion
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
                        v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                }
                property.SetColumnName(ToSnakeCase(property.Name));
            }
        }
    }

    private string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
}
