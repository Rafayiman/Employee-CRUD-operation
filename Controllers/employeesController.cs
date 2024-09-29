using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice.Data;
using practice.Models.DataTransferObject;
using practice.Models.Entities;

namespace practice.Controllers
{
    // local host :xxx/api/employees
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class employeesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public employeesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        // iactionresult is a return datatype
        public IActionResult getEmployees()
        {
            var allEmployees = context.Employee.ToList();
            return Ok(allEmployees);

        }

        [HttpGet]
        [Route("{Id:guid}")]

        public IActionResult getEmployeebyId(Guid Id)
        {
            var employee = context.Employee.Find(Id);

            if (employee == null)
            {
                return NotFound();
            }
            else
                return Ok(employee);
        }

        [HttpPost]

        public IActionResult addEmployee(addemployeesDTO dTO)
        {
            var employeeEntity = new Employees()
            {
                Email = dTO.Email,
                Name = dTO.Name,
                Salary = dTO.Salary,
                Phone = dTO.Phone,
            };

            context.Employee.Add(employeeEntity);
            context.SaveChanges();

            return Ok(employeeEntity);


        }
        [HttpPut]
        [Route("{Id:guid}")]

        public IActionResult updateEmployees(Guid Id, updateEmployeeDTO dTo)
        {
            var employee = context.Employee.Find(Id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {

                employee.Email = dTo.Email;
                employee.Name = dTo.Name;
                employee.Phone = dTo.Phone;
                employee.Salary = dTo.Salary;



                context.SaveChanges();
                return Ok(employee);
            }


        }
        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = context.Employee.Find(id);

            if (employee == null)
            {
                return NotFound();

            }
            context.Employee.Remove(employee);
            context.SaveChanges();

            return Ok();

        }

    }
}
