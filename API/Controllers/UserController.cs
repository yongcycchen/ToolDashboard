using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController: BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult> GetCurrentUser()
        {
            var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return Ok(user);
        }
    }
}