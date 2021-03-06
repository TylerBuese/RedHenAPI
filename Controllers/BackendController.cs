using Microsoft.AspNetCore.Mvc;
using RedHenAPI.Models;
using RedHenAPI.Backend;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RedHenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackendController : ControllerBase
    {
        [HttpGet]
        public IActionResult IsOnline()
        {
            try
            {
                return Ok(new { Result = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateParent")]
        public IActionResult CreateParent(
            [FromQuery] string Password,
            [FromQuery] string FirstName,
            [FromQuery] string LastName,
            [FromQuery] string Email,
            [FromQuery] bool IsParent)
        {
            try
            {
                var account = new AccountModel
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    isParent = IsParent,
                    Password = Password
                };
                var dbInstance = new database();
                dbInstance.AddParent(account);
                return Ok(new { Result = true });
            } catch (Exception ex)
            {
                return StatusCode(500, new {Result = ex.Message});
            }
            
        }

        [HttpGet("GetParent")]
        public async Task<ActionResult<Object>> GetParent([FromQuery]int accountNumber)
        {

            var db = new database();
            var account = db.GetParent(accountNumber);
            return account;
        }


    }




}

