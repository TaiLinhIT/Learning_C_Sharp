using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS40EntityFramework.Models
{
    public class ProductDbcontext : DbContext
    {
        private const string ConnectionString = "Data Source=SYSSANG\\SQLEXPRESS;Initial Catalog=anhlinh;User ID=linh;Password=123;TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
