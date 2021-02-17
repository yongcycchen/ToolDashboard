using API.Interfaces;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        public string GetUser()
        {
            var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return user;
        }
    }
}