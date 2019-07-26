using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDoTorqueti2._0.Domain.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Token { get; set; }
    }
}
