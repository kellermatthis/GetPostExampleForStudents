using Microsoft.AspNetCore.Mvc;

namespace PostTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _logger.Log(LogLevel.Information, student.ToString());

            if (student is null || string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName))
                return BadRequest();

            // DO Database magic

            return StatusCode(201, student);
        }
    }
}