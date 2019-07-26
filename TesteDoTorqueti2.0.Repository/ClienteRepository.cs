using TesteDoTorqueti2._0.Domain.Models;
using TesteDoTorqueti2._0.Repository.Interfaces;

namespace TesteDoTorqueti2._0.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClientesRepository
    {
        public ClienteRepository(RepositoryContext context) : base(context) { }
    }
}
