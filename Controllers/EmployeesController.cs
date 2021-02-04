using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPex1.Models;
using Microsoft.AspNetCore.Cors;

namespace ASPex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private List<Employee> employeesList = new List<Employee>();

        private Employee FindEmployeeById(long id)
        {
            return employeesList.Find(x => x.Id == id);
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return employeesList;
            }
            catch
            {
                List<Employee> empty = new List<Employee>();
                Employee emp = new Employee();
                empty.Add(emp);
                return empty;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(long id)
        {
            var employee = FindEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(long id, Employee Employee)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }
            
            try
            {
                var e = FindEmployeeById(id);
                if (e == null)
                {
                    return NotFound();
                }

                e = Employee;
            }
            catch (Exception ex)
            {
               throw;

            }

            return Ok();
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee Employee)
        {
            var employee = new Employee
            {
                Name = Employee.Name,
                Surname = Employee.Surname,
                Position = Employee.Position,
                Salary = Employee.Salary
            };

            employeesList.Add(employee);
            

            return CreatedAtAction(nameof(GetEmployee),new { id = employee.Id },employee);
        }

        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(long id)
        {
            var employee = FindEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            employeesList.Remove(employee);

            return CreatedAtAction(nameof(GetEmployee),new { id = employee.Id },employee); 
        }
    }
}
