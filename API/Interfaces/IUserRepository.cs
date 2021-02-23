using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        public Task<FSUser> GetUserByFSIdAsync(string FSId);
    }
}