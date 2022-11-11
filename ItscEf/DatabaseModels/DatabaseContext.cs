using ItscEf.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ItscEf.DatabaseModels
{
    public partial class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)       
        {

        }

        public DbSet<TblDepartment> TblDepartments { get; set; }
        public DbSet<TblPosition> TblPosition { get; set; }
        public DbSet<TblEmployee> TblEmployee { get; set; }
        public DbSet<TblProject> TblProject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\sql2019;uid=sa;password=aong;database=workshop;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDepartment();
        }

    }
}
