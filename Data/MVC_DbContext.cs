using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MVC_Identity.Models;
namespace MVC_Identity.Data
{
    public class MVC_DbContext : IdentityDbContext<ApplicationUser>
    {
        public MVC_DbContext(DbContextOptions<MVC_DbContext> options)
            : base(options)
        {

        }

        public DbSet<Person> People { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);



            modelbuilder.Entity<Language>().HasData(new Language { Id = 1, Name = "Svenska" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = 2, Name = "'Murican" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = 3, Name = "Polski" });

            modelbuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Sweden" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "'Murica" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Poland" });

            modelbuilder.Entity<City>().HasData(new City { Id = 1, CountryId = 1, Name = "Gothenburg" });
            modelbuilder.Entity<City>().HasData(new City { Id = 2, CountryId = 2, Name = "Central Pennsylvania" });
            modelbuilder.Entity<City>().HasData(new City { Id = 3, CountryId = 3, Name = "Gdansk" });

            modelbuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Siavash Gosheh", PhoneNumber = "xxxx-xxx666", CityId = 1 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = 2, Name = "Maxwell T Bird", PhoneNumber = "Mr. Max Tv @ Youtube", CityId = 2 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = 3, Name = "Nergal", PhoneNumber = "666", CityId = 3 });

            modelbuilder.Entity<Person>()
                .HasMany(l => l.Languages)
                .WithMany(p => p.People)
                .UsingEntity(j => j.HasData(new { LanguagesId = 1, PeopleId = 1 }));
            modelbuilder.Entity<Person>()
                .HasMany(l => l.Languages)
                .WithMany(p => p.People)
                .UsingEntity(j => j.HasData(new { LanguagesId = 2, PeopleId = 2 }));
            modelbuilder.Entity<Person>()
                .HasMany(l => l.Languages)
                .WithMany(p => p.People)
                .UsingEntity(j => j.HasData(new { LanguagesId = 3, PeopleId = 3 }));

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelbuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            modelbuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"

            });

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            modelbuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                FirstName = "Admin",
                LastName = "Adminson",
                Age = 29,
                PasswordHash = passwordHasher.HashPassword(null, "password")
            });

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
               RoleId = adminRoleId,
               UserId = userId,
            });

        }
    }
}

