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

            modelBuilder.Entity<TblPosition>().HasData(
                new TblPosition() { Id=1, Name="Admin", DepartmentId= 1},
                new TblPosition() { Id = 2, Name = "Manager", DepartmentId = 1 },
                new TblPosition() { Id = 3, Name = "IT", DepartmentId = 1 },
                new TblPosition() { Id = 4, Name = "Developer", DepartmentId = 2 },
                new TblPosition() { Id = 5, Name = "UXUI", DepartmentId = 2 }
                );
        }
    }
}
