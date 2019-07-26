using TesteDoTorqueti2._0.Domain.Models;
using TesteDoTorqueti2._0.Repository.Interfaces;

namespace TesteDoTorqueti2._0.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context) { }
    }
}
