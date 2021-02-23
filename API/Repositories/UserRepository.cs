using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<FSUser> GetUserByFSIdAsync(string FSId)
        {
            // var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var user = await _context.Users
                .Where(x =>x.UserName == FSId)
                .SingleOrDefaultAsync();
            return user;
        }
    }
}