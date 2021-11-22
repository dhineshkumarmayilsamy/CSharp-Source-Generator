using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SourceGenSampleAPI.Models;

namespace SourceGenSampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost("[action]")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {

            //var empDto = new EmployeeDto()
            //{
            //    EmpId = employee.EmpId,
            //    Designation = employee.Designation,
            //    Email2 = employee.Email2,
            //    Name = employee.Name
            //};

            return Ok();

        }
    }
}