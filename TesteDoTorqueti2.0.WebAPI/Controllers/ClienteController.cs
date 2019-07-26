using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using TesteDoTorqueti2._0.Domain.Models;
using TesteDoTorqueti2._0.Service.Interfaces;

namespace TesteDoTorqueti2._0.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ClienteController : ApiController
    {
        private readonly IClienteService clienteService;
        private readonly IUserService userService;
        public ClienteController(IClienteService clienteService, IUserService userService)
        {
            this.clienteService = clienteService;
            this.userService = userService;
        }

        [AllowAnonymous]
        [ActionName("authenticate")]
        public IHttpActionResult Authenticate([FromBody]User user)
        {
            var login = this.userService.Authenticate(user.Login, user.Senha);

            if (login == null)
                return Content(HttpStatusCode.BadRequest, "Login ou senha incorreto!");
            return Ok(login);
        }

        [HttpGet]
        [ActionName("List")]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<Cliente> cliente = this.clienteService.GetAll().ToList();
                if (cliente.Count <= 0)
                    return Content(HttpStatusCode.NoContent, "Nenhum Objeto");
                else
                    return Content(HttpStatusCode.OK, cliente);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, "Não Encontrado!");
            }
        }

        // GET api/values/5
        [HttpGet]
        [ActionName("Get")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                Cliente cliente = this.clienteService.GetById(id);
                if (cliente == null)
                    return Content(HttpStatusCode.NoContent, "Nenhum Objeto");
                else
                    return Content(HttpStatusCode.OK, cliente);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.OK, "Nenhum Objeto");
            }
        }

        // POST api/values
        [HttpPost]
        [ActionName("Post")]
        public IHttpActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                this.clienteService.Insert(cliente);
                return Content(HttpStatusCode.Created, "Nenhum Objeto");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, "Nenhum Objeto");
            }
        }

        // PUT api/values/5
        [HttpPut]
        [ActionName("Put")]
        public IHttpActionResult Put(int id, [FromBody]Cliente cliente)
        {
            try
            {
                this.clienteService.Update(cliente);
                return Content(HttpStatusCode.NoContent, "Nenhum Objeto");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, "Nenhum Objeto");
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [ActionName("Delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.clienteService.Delete(id);
                return Content(HttpStatusCode.Accepted, "Nenhum Objeto");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, "Nenhum Objeto");
            }
        }
    }
}
