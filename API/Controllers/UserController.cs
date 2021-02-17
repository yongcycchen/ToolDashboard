using System;
using System.Net.Mail;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult> GetCurrentUser()
        {
            var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return Ok(user);
        }
    }
}