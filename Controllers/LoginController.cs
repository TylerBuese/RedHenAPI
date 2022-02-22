using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace RedHenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult IsOnline()
        {
            try
            {
                return Ok(new { Result = true });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Logon")]
        public ActionResult<object> Logon()
        {
            return Ok(new { Result = true });
        }

        [HttpGet("Logoff")]
        public ActionResult<object> Logoff()
        {
            return Ok(new { Result = true });
        }
    }
}
