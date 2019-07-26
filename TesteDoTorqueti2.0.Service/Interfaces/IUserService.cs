using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDoTorqueti2._0.Domain.Models;

namespace TesteDoTorqueti2._0.Service.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User Authenticate(string login, string senha);
    }
}
