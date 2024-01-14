using FlowersInYou.Controllers;
using FlowersInYou.Models;
using FlowersInYou.Repositories;
using FlowersInYou.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersInYou.Tests.Tests
{
    public class ClientsControllerTests
    {
        private IClientService _clientService = new ClientService(
            new ClientRepository(new FlowersInYouContext()), 
            new BusketRepository(new FlowersInYouContext()));

        [Fact]
        public void GetClientsListTest()
        {
            var controller = new ClientsController(_clientService);

            var result = controller.GetClientsList().Value as IEnumerable<Client>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Client>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetClientTest()
        {
            var controller = new ClientsController(_clientService);

            var result = controller.GetClient(2).Value as Client;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Client>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateClientRedirectTest()
        {
            var controller = new ClientsController(_clientService);

            var newClient = new Client {
                Login = "login", 
                Password = "password", 
                LastName = "lastname", 
                FirstName = "firstname", 
                Patronymic = "patronymic", 
                PhoneNumber = "88005553535", 
                Email = "email@mail.ru"};

            var result = controller.CreateClient(newClient);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetClientsList", redirectToActionResult.ActionName);

            var newEmptyClient = new Client();
            var emptyResult = controller.CreateClient(newEmptyClient);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void UpdateClientRedirectTest()
        {
            var controller = new ClientsController(_clientService);

            var newClient = (controller.GetClientsList().Value as IEnumerable<Client>).Last();
            newClient.Login = "client";

            var result = controller.UpdateClient(newClient.Id, newClient);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetClientsList", redirectToActionResult.ActionName);

            var newEmptyClient = new Client();
            var emptyResult = controller.UpdateClient(0, newEmptyClient);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteClientRedirectTest()
        {
            var controller = new ClientsController(_clientService);

            var newClient = (controller.GetClientsList().Value as IEnumerable<Client>).Last();

            var result = controller.DeleteClient(newClient.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetClientsList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteClient(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
