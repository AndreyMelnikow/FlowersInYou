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
    public class OrdersControllerTests
    {
        private IOrderService _orderService = new OrderService(
            new OrderRepository(new FlowersInYouContext()),
            new BusketOrderRepository(new FlowersInYouContext()),
            new CourierRepository(new FlowersInYouContext()),
            new FloristRepository(new FlowersInYouContext()),
            new BusketRepository(new FlowersInYouContext()));

        [Fact]
        public void GetOrderListTest()
        {
            var controller = new OrdersController(_orderService);

            var result = controller.GetOrdersList().Value as IEnumerable<Order>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Order>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetUnacceptedOrderInfoTest()
        {
            var controller = new OrdersController(_orderService);

            var result = controller.GetUnacceptedOrderInfo().Value;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<object>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetOrderTest()
        {
            var controller = new OrdersController(_orderService);

            var result = controller.GetOrder(1).Value as Order;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Order>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateOrderRedirectTest()
        {
            var controller = new OrdersController(_orderService);

            var newOrder = new Order
            {
                Address = "address",
                Decription = "description",
                Range = 100,
                IsPaid = true,
            };

            var result = controller.CreateOrder(newOrder, 2);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetOrdersList", redirectToActionResult.ActionName);

            var newEmptyOrder = new Order();
            var emptyResult = controller.CreateOrder(newEmptyOrder, 0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteOrderRedirectTest()
        {
            var controller = new OrdersController(_orderService);

            var newOrder = (controller.GetOrdersList().Value as IEnumerable<Order>).Last();

            var result = controller.DeleteOrder(newOrder.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetOrdersList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteOrder(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
