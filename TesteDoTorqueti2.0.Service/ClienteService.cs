﻿using System.Collections.Generic;
using TesteDoTorqueti2._0.Domain.Models;
using TesteDoTorqueti2._0.Repository.Interfaces;
using TesteDoTorqueti2._0.Service.Interfaces;

namespace TesteDoTorqueti2._0.Service
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClientesRepository repository;
        public ClienteService(IClientesRepository repository) : base(repository) => this.repository = repository;

        public IEnumerable<Cliente> GetById(int id) => this.repository.GetByCondition(x => x.Id == id);
    }
}
