using FlowersInYou.Controllers;
using FlowersInYou.Models;
using FlowersInYou.Repositories;
using FlowersInYou.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace FlowersInYou.Tests.Tests
{
    public class BusketsControllerTests
    {
        private IBusketService _busketService = new BusketService(
            new BusketRepository(new FlowersInYouContext()));

        [Fact]
        public void GetBusketListTest()
        {
            var controller = new BusketsController(_busketService);

            var result = controller.GetBusketList().Value as IEnumerable<Busket>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Busket>>(result);
            Assert.Equal(result, model);
        }
    }
}