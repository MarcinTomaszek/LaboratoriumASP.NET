using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts {get; set;}

    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
                {Id = 1,FirstName = "Lukas",LastName = "Janus",Email = "LukasJanus@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,03,18), PhoneNumber = "607 758 331",Category = Category.Business,Created = DateTime.Now},
            new ContactEntity()
                {Id = 2,FirstName = "Pawel",LastName = "Wrona",Email = "PawelWrona@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,07,18), PhoneNumber = "111 222 333",Category = Category.Business,Created = DateTime.Now},
            new ContactEntity()
                {Id = 3,FirstName = "Kacper",LastName = "Wojas",Email = "KacperWojas@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2005,03,18), PhoneNumber = "412 123 123",Category =Category.Business,Created = DateTime.Now}
            );
    }
}