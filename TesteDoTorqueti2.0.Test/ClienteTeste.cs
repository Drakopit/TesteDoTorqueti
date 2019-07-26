using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteDoTorqueti2._0.Repository;
using TesteDoTorqueti2._0.Service;
using TesteDoTorqueti2._0.WebAPI.Controllers;

namespace TesteDoTorqueti2._0.Test
{
    [TestClass]
    public class ClienteTeste
    {
        [TestMethod]
        public void TestaClienteControllerResposta()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("Default", "{controller}/{action}/{id}");
            HttpServer server = new HttpServer(config);
            using (HttpMessageInvoker client = new HttpMessageInvoker(server))
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/Movies/-1"))
                using (HttpResponseMessage response = client.SendAsync(request, CancellationToken.None).Result)
                {
                    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
                }
            };

            // Arrange
            RepositoryContext repositoryContext = new RepositoryContext();
            ClienteRepository clienteRepository = new ClienteRepository(repositoryContext);
            ClienteService clienteService = new ClienteService(clienteRepository);
            ClienteController controller = new ClienteController(clienteService);

            // Act
            var result = controller.GetAll() as List<Cliente>;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestaClienteControllerResposta()
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute("Default", "{controller}/{action}/{id}");
            HttpServer server = new HttpServer(config);
            using (HttpMessageInvoker client = new HttpMessageInvoker(server))
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/Movies/-1"))
                using (HttpResponseMessage response = client.SendAsync(request, CancellationToken.None).Result)
                {
                    Cliente content = Assert.IsInstanceOfType(response.Content, Type.GetType(Cliente), "Igual");
                    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
                }
            };

            // Arrange
            RepositoryContext repositoryContext = new RepositoryContext();
            ClienteRepository clienteRepository = new ClienteRepository(repositoryContext);
            ClienteService clienteService = new ClienteService(clienteRepository);
            ClienteController controller = new ClienteController(clienteService);

            // Act
            var result = controller.GetAll() as List<Cliente>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
