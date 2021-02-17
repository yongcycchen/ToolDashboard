using API.Interfaces;

namespace API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository => new UserRepository();
    }
}