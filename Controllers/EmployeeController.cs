using API_CRUD_USING_DB.data;
using API_CRUD_USING_DB.Models;
using API_CRUD_USING_DB.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace API_CRUD_USING_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allemployee = dbContext.Employees.ToList();
            return Ok(allemployee);
        }


        [HttpPost]

        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary,
            };

             dbContext.Employees.Add(employeeEntity);
             dbContext.SaveChanges();
            return Ok(employeeEntity);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
           var employee =  dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                  return NotFound();
            }
            employee.Name = updateEmployeeDTO.Name;
            employee.Email = updateEmployeeDTO.Email;
            employee.Phone = updateEmployeeDTO.Phone;
            employee.Salary = updateEmployeeDTO.Salary;
            dbContext.SaveChanges();
            return Ok(employee);



        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee=dbContext.Employees.Find(id);
            if (employee == null)
            {

                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }


    }
}
