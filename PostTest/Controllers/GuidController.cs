using Microsoft.AspNetCore.Mvc;

namespace PostTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuidController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public Guid Get()
        {
            return Guid.NewGuid();
        }

        [HttpGet]
        [Route("WithStart")]
        public IActionResult Get([FromQuery(Name = "startLetter")] string startLetter)
        {
            if (startLetter.Count() != 1)
                return BadRequest("startletter is not one character");

            if (!System.Text.RegularExpressions.Regex.IsMatch(startLetter, @"\A\b[0-9a-fA-F]+\b\Z"))
                return BadRequest("startLetter doesnt start with valid hex value");

            var guid = Guid.NewGuid();
            while (!guid.ToString().StartsWith(startLetter.ToLower()))
            {
                guid = Guid.NewGuid();
            }
            return Ok(guid);
        }
    }
}
