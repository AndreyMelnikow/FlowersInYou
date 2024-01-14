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
    public class ConfirmedOrdersControllerTests
    {
        private IConfirmedOrderService _confirmedOrderService = new ConfirmedOrderService(
            new ConfirmedOrderRepository(new FlowersInYouContext()),
            new OrderRepository(new FlowersInYouContext()),
            new ZoneRepository(new FlowersInYouContext()),
            new CourierRepository(new FlowersInYouContext()),
            new FloristRepository(new FlowersInYouContext()));

        [Fact]
        public void GetConfirmedOrdersListTest()
        {
            var controller = new ConfirmedOrdersController(_confirmedOrderService);

            var result = controller.GetConfirmedOrdersList().Value as IEnumerable<ConfirmedOrder>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<ConfirmedOrder>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetConfirmedOrderTest()
        {
            var controller = new ConfirmedOrdersController(_confirmedOrderService);

            var result = controller.GetConfirmedOrder(7).Value as ConfirmedOrder;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<ConfirmedOrder>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateConfirmedOrderRedirectTest()
        {
            var controller = new ConfirmedOrdersController(_confirmedOrderService);

            var newConfirmedOrder = new ConfirmedOrder
            {
                IdOrder = 1,
            };

            var result = controller.CreateConfirmedOrder(newConfirmedOrder, "87777777777", "88888888888");

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetConfirmedOrdersList", redirectToActionResult.ActionName);

            var newEmptyConfirmedOrder = new ConfirmedOrder();
            var emptyResult = controller.CreateConfirmedOrder(newEmptyConfirmedOrder, "0", "0");

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteConfirmedOrderRedirectTest()
        {
            var controller = new ConfirmedOrdersController(_confirmedOrderService);

            var newConfirmedOrder = (controller.GetConfirmedOrdersList().Value as IEnumerable<ConfirmedOrder>).Last();

            var result = controller.DeleteConfirmedOrder(newConfirmedOrder.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetConfirmedOrdersList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteConfirmedOrder(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
