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
            optionsBuilder.UseSqlServer("Server =DESKTOP-7TAP9Q7\\SQLEXPRESS;Database=billing_system; Trusted_Connection = True; ");
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
        public DbSet<ClientLog> ClientLog { get; set; }
        public DbSet<IPAdress> IPS { get; set; }
    }
}
    

