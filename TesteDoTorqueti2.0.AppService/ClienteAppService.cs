using TesteDoTorqueti2._0.AppService.Interfaces;
using TesteDoTorqueti2._0.Service.Interfaces;

namespace TesteDoTorqueti2._0.AppService
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService clienteService;
        public ClienteAppService(IClienteService clienteService) { this.clienteService = clienteService; }
    }
}
