using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjects.Data;
using WebApiProjects.DTO;
using WebApiProjects.Models;

namespace WebApiProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        AppDbContext DB = new AppDbContext();

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(DB.Departments.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id) {
            return Ok(DB.Departments.Find(id));
        }

        [HttpPost]
        public IActionResult Create(DtoDepartment dtoDepartment)
        {
            Department department = new Department {Name=dtoDepartment.Name };
            DB.Departments.Add(department);
            DB.SaveChanges();
            return Ok(new { message="Department Created Successfully"});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            DB.Departments.Remove(DB.Departments.Find(id));
            DB.SaveChanges();
            return Ok(new { message = "Department Deleted Successfully" });
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id , DtoDepartment dtoDepartment)
        {
            var department = new Department {Id=id, Name=dtoDepartment.Name };
            DB.Departments.Update(department);
            DB.SaveChanges();
            return Ok(new { message = "Department Updated Successfully" });
        }
    }
}
