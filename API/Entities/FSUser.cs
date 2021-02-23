using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class FSUser : IdentityUser<int> 
    {
        public string FSID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserTool> NotificationList { get; set; }
        public ICollection<FSUserRole> UserRoles { get; set; }
    }
}