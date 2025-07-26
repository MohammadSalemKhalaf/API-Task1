using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjects.Data;
using WebApiProjects.DTO;
using WebApiProjects.Models;

namespace WebApiProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        AppDbContext DB= new AppDbContext();

        [HttpGet()]
        public IActionResult getAll() =>  Ok(DB.Employees.ToList());


        [HttpGet("{id}")]
        public IActionResult getById(int id) => Ok(DB.Employees.Find(id));

        [HttpPost]
        public IActionResult Create(DtoEmployee dtoEmployee)
        {
            var employee = new Employee {Name=dtoEmployee.Name,Email=dtoEmployee.Email,Phone=dtoEmployee.Phone,Salary=dtoEmployee.Salary,DepartmentId=dtoEmployee.DepartmentId };

            DB.Employees.Add(employee);
            DB.SaveChanges();
            return Ok(new { message="Employee Created Successfully"});
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = DB.Employees.Find(id);
            DB.Employees.Remove(employee);
            DB.SaveChanges();
            return Ok(new { message="Employee Deleted Successfully"});
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id,DtoEmployee dtoEmployee)
        {
            var employee = new Employee {Name=dtoEmployee.Name,Email=dtoEmployee.Email,Phone=dtoEmployee.Phone,Salary=dtoEmployee.Salary,DepartmentId=dtoEmployee.DepartmentId,Id=id };

            DB.Employees.Update(employee);
            DB.SaveChanges();
            return Ok(new { message = "Employee Edited Successfully" });

        }

    }
}
