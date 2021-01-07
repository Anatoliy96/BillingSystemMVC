using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.DAO
{
    public class BillingSystemContext : DbContext
    {
        public BillingSystemContext(DbContextOptions<BillingSystemContext> options)
            : base(options)
        {
        }

        public BillingSystemContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=billing_system;Uid=root;Pwd=root");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
           
        }
        
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }

    }
}
    

