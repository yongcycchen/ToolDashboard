using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class FSUserRole: IdentityUserRole<int>
    {
        public FSUser User { get; set; }
        public FSRole Role { get; set; }
    }
}