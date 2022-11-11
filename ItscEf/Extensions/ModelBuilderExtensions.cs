using ItscEf.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace ItscEf.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedDepartment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>().HasData(
                new TblDepartment() { Id=1,Name="Office"},
                new TblDepartment() { Id=2,Name="Production"}
                );
        }
    }
}
