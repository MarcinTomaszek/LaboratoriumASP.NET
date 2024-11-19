using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: IdentityDbContext<IdentityUser>
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
        base.OnModelCreating(modelBuilder);

        string ADMIN_ID = Guid.NewGuid().ToString();
        string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
        
        string USER_ID = Guid.NewGuid().ToString();
        string USER_ROLE_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = ADMIN_ROLE_ID
            },
            
            new IdentityRole()
                {
                    Id = USER_ROLE_ID,
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = USER_ROLE_ID
                }
        );

        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            Email = "admin@wsei.pl",
            NormalizedEmail = "admin@wsei.pl".ToUpper(),
            UserName = "admin",
            NormalizedUserName = "admin".ToUpper(),
            EmailConfirmed = true
        };
        
        var user = new IdentityUser()
        {
            Id = USER_ID,
            Email = "user@wsei.pl",
            NormalizedEmail = "user@wsei.pl".ToUpper(),
            UserName = "user",
            NormalizedUserName = "user".ToUpper(),
            EmailConfirmed = true
        };

        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = hasher.HashPassword(admin, "admin");
        user.PasswordHash = hasher.HashPassword(user, "user");

        modelBuilder.Entity<IdentityUser>().HasData(admin, user);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            },
            
            new IdentityUserRole<string>()
            {
                RoleId = USER_ROLE_ID,
                UserId = ADMIN_ID
            },
            
            new IdentityUserRole<string>()
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            }
        );
        
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