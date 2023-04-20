using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM_API_041923.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRM_API_041923.Controllers
{
    // By default, mac creates a MVC controller
    [Route("api/[controller]")]
    [ApiController] // Mac need to add [ApiController]
    public class EmployeeController : ControllerBase // Mac need to manually change Controller to ControllerBase
    {
        private readonly List<EmployeeModel> _employees;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _employees = new List<EmployeeModel>
            {
                new EmployeeModel { Id = 1, Name = "Kate", Salary = 65000 },
                new EmployeeModel { Id = 2, Name = "Lisa", Salary = 80000 },
                new EmployeeModel { Id = 3, Name = "Amy", Salary = 50000 }
            };
            _logger = logger;
        }

        /*[HttpGet]
        public IActionResult GetWelcomeMessage()
        {
            return Ok(); // If application works, server response OK
            //return NotFound(); // If page not found. 404 code
            //return BadRequest(); // 400 code
        }
        */

        [HttpGet]
        public IActionResult GetEmployee()
        {
            /* Primitive type data
             * var employees = new List<string>
            {
                "Kate", "Lisa", "Amy"
            };*/
            return Ok(_employees);
        }

        // Dynamic routing/url: use for retreiving data
        [HttpGet]
        [Route("GetById/{id:min(1):max(3)}")]
        public IActionResult GetById(int id)
        {
            var result = _employees.Find(x => x.Id == id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Employee not Found");
        }

        // Query string: use for search/query data
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var result = _employees.First(x => x.Name == name);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Employee not Found");
        }

        [HttpGet("Search")]
        public IActionResult SearchEmployee(int id, string name)
        {
            return Ok( id + " " + name);
        }

        [HttpGet("ExceptionHandling")]
        public IActionResult ExceptionHandling(string input)
        {
            throw new NullReferenceException();
        }
    }
}

