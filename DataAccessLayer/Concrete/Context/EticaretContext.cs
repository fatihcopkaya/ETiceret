using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Utilities.Security.Hashing;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccessLayer.Concrete.Context
{
    public class EticaretContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string ConnetDeveloper = "server=localhost;port=3306;database=Eticaret;user=root;password=12345678;Charset=utf8;";

            optionsBuilder.UseLazyLoadingProxies()
                .UseMySql(ConnetDeveloper, ServerVersion.AutoDetect(ConnetDeveloper))
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(warnings =>
                {
                    warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
                });
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductPhoto>? ProductPhotos { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var admin = new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                PhoneNumber = "+905468778232",
                IsActived = true,
                Role = "Admin"
            };
            HashingHelper.CreatePasswordHash("Admin123", out var passwordHash, out var passwordSalt);
            admin.PasswordSalt = passwordSalt;
            admin.PasswordHash = passwordHash;
            modelBuilder.Entity<User>().HasData(admin);
            base.OnModelCreating(modelBuilder);


        }
    }
}