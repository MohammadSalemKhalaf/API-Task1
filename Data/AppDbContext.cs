using Microsoft.EntityFrameworkCore;
using WebApiProjects.Models;

namespace WebApiProjects.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=JAWADHAMDAN;Database=Api_Task1;Trusted_Connection=True;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department {Id=1,Name="Accounting" },
                new Department {Id=2,Name="Customer Service" }

                );

            modelBuilder.Entity<Employee>().HasData(
     new Employee
     {
         Id = 1,
         Name = "John Doe",
         Email = "john.doe@example.com",
         Phone = "123-456-7890",
         Salary = 50000m,
         DepartmentId = 1
     },
     new Employee
     {
         Id = 2,
         Name = "Jane Smith",
         Email = "jane.smith@example.com",
         Phone = "987-654-3210",
         Salary = 60000m,
         DepartmentId = 2
     },
     new Employee
     {
         Id = 3,
         Name = "Michael Johnson",
         Email = "michael.johnson@example.com",
         Phone = "555-123-4567",
         Salary = 55000m,
         DepartmentId = 1
     },
     new Employee
     {
         Id = 4,
         Name = "Emily Davis",
         Email = "emily.davis@example.com",
         Phone = "444-789-1234",
         Salary = 53000m,
         DepartmentId = 1
     },
     new Employee
     {
         Id = 5,
         Name = "David Wilson",
         Email = "david.wilson@example.com",
         Phone = "333-222-1111",
         Salary = 52000m,
         DepartmentId = null 
     },
     new Employee
     {
         Id = 6,
         Name = "Sophia Martinez",
         Email = "sophia.martinez@example.com",
         Phone = "777-888-9999",
         Salary = 58000m,
         DepartmentId = 2
     }
 );


        }

    }
}
