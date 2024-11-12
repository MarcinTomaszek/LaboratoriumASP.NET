using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts {get; set;}
    public DbSet<OrganizationEntity> Organizations { get; set; }

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
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Name = "WSEI",
                    NIP = "1283234",
                    REGON = "21313124",
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    Name = "PKP",
                    NIP = "5327825",
                    REGON = "8658345",
                }
            );

        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne<Address>(o => o.Address)
            .HasData(
                new {
                    City = "Kraków",
                    Street = "św. Filipa 17",
                    OrganizationEntityId = 101
                },
                new {
                    City = "Limanowa",
                    Street = "Nowy sacz",
                    OrganizationEntityId = 102
                }
            );
            
            
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
                {Id = 1,FirstName = "Lukas",LastName = "Janus",Email = "LukasJanus@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,03,18), PhoneNumber = "607 758 331",Category = Category.Business,Created = DateTime.Now,OrganizationId = 102},
            new ContactEntity()
                {Id = 2,FirstName = "Pawel",LastName = "Wrona",Email = "PawelWrona@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,07,18), PhoneNumber = "111 222 333",Category = Category.Business,Created = DateTime.Now,OrganizationId = 101},
            new ContactEntity()
                {Id = 3,FirstName = "Kacper",LastName = "Wojas",Email = "KacperWojas@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2005,03,18), PhoneNumber = "412 123 123",Category =Category.Business,Created = DateTime.Now,OrganizationId = 101}
            );
    }
}