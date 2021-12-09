using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Infrastructure
{
    public class LgwDbContex : DbContext
    {
        public string DEFAULT_SHEMA = "lgwCase";
        public IConfiguration Configuration { get; }

        public LgwDbContex(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connStr,configure =>
            {
                configure.MigrationsAssembly("LgwCase.Services.Product.Infrastructure");
            });

        }

        //public LgwDbContex(DbContextOptions<LgwDbContex> options) : base(options)
        //{

        //}
        public DbSet<Domain.Product.Product> Products { get; set; }

        public DbSet<Domain.Product.Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Product.Product>().ToTable("Products", DEFAULT_SHEMA);
            modelBuilder.Entity<Domain.Product.Category>().ToTable("Categories", DEFAULT_SHEMA);

            modelBuilder.Entity<Domain.Product.Product>().Property(x => x.Title).HasColumnType("nvarchar(200)");
        }
    }
}
