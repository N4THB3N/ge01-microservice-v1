using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Models;


namespace UserService.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options){

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.First_Name).HasColumnType("varchar(25)");
            modelBuilder.Entity<User>().Property(x => x.Last_Name).HasColumnType("varchar(35)");
            modelBuilder.Entity<User>().Property(x => x.Username).HasColumnType("varchar(30)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnType("varchar(150)");
            modelBuilder.Entity<User>().Property(x => x.Created_At).HasColumnType("datetime");
            modelBuilder.Entity<User>().Property(x => x.Updated_At).HasColumnType("datetime");
        }
        
    }
}