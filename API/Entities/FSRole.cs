using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class FSRole: IdentityRole<int>
    {
        public ICollection<FSUserRole> UserRoles {get; set;}
    }
}