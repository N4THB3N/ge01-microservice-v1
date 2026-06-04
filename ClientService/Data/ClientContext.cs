using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Data
{
    public class ClientContext:DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options):base(options)
        {
            
        }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().Property(x => x.First_Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<Client>().Property(x => x.Last_Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<Client>().Property(x => x.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<Client>().Property(x => x.Phone_Number).HasColumnType("varchar(20)");
            modelBuilder.Entity<Client>().Property(x => x.Addr1).HasColumnType("varchar(100)");
            modelBuilder.Entity<Client>().Property(x => x.Municipality).HasColumnType("varchar(50)");
            modelBuilder.Entity<Client>().Property(x => x.Department).HasColumnType("varchar(50)");
            modelBuilder.Entity<Client>().Property(x => x.Occupation).HasColumnType("varchar(50)");
            modelBuilder.Entity<Client>().Property(x => x.DOB).HasColumnType("date");
            modelBuilder.Entity<Client>().Property(x => x.Created_At).HasColumnType("datetime");
            modelBuilder.Entity<Client>().Property(x => x.Updated_At).HasColumnType("datetime");
        }
        
    }
}