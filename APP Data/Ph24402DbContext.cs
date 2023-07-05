using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
    public class Ph24402DbContext : DbContext
    {
        public Ph24402DbContext()
        {
        }
        public Ph24402DbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DESKTOP-ECEQI3B;Initial Catalog=Luong_The_Hoan_ph24402;Integrated Security=True"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<NhanVien> NhanViens { get; set; }
    }
}
