using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifim.Data.Entities;

namespace Tarifim.Data.Context
{
    public class TarifimContext : DbContext
    {
        private readonly IDataProtector _dataProtector;

        public TarifimContext(DbContextOptions<TarifimContext> options, IDataProtectionProvider dataProtectionProvider) : base(options)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<FoodEntity> Foods => Set<FoodEntity>();

        public DbSet<UserEntity> Users => Set<UserEntity>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FoodEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            var adminPassword = "123";
            var userPassword = "123";
            adminPassword = _dataProtector.Protect(adminPassword);
            userPassword = _dataProtector.Protect(userPassword);

            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id = 1,
                    Name = "admin",
                    SurName = "admin",
                    Email = "admin@tarifim.com",
                    Password = adminPassword, 
                    UserType = Enums.UserTypeEnum.admin
                },
                new UserEntity()
                {
                    Id = 2,
                    Name = "user",
                    SurName = "user",
                    Email = "user@tarifim.com",
                    Password = userPassword,
                    UserType = Enums.UserTypeEnum.user
                }
            });



            base.OnModelCreating(modelBuilder);
        }
    }
}
