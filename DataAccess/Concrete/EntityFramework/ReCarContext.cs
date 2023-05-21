using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCarContext : DbContext

    {

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; } //DbSet<Car> Cars = Cars tablosu demek

        public DbSet<Brand> Brands { get; set; } // DbSet<Brand> Brands = Brands tablosu demek

        public DbSet<Color> Colors { get; set; } // DbSet<Color> Colors = Colors tablosu demek





    }
}
