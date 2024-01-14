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
    public class CouriersControllerTests
    {
        private ICourierService _courierService = new CourierService(
            new CourierRepository(new FlowersInYouContext()));

        [Fact]
        public void GetCouriersListTest()
        {
            var controller = new CouriersController(_courierService);

            var result = controller.GetCouriersList().Value as IEnumerable<Courier>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Courier>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetCourierTest()
        {
            var controller = new CouriersController(_courierService);

            var result = controller.GetCourier(1).Value as Courier;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Courier>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateCourierRedirectTest()
        {
            var controller = new CouriersController(_courierService);

            var newCourier = new Courier
            {
                IsActive = true,
                RangeMax = 15000,
                LastName = "lastname",
                FirstName = "firstname",
                Patronymic = "patronymic",
                PhoneNumber = "87777777777",
                Email = "email@gmail.com"
            };

            var result = controller.CreateCourier(newCourier);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCouriersList", redirectToActionResult.ActionName);

            var newEmptyCourier = new Courier();
            var emptyResult = controller.CreateCourier(newEmptyCourier);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void UpdateCourierRedirectTest()
        {
            var controller = new CouriersController(_courierService);

            var newCourier = (controller.GetCouriersList().Value as IEnumerable<Courier>).Last();
            newCourier.LastName = "courier";

            var result = controller.UpdateCourier(newCourier.Id, newCourier);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCouriersList", redirectToActionResult.ActionName);

            var newEmptyCourier = new Courier();
            var emptyResult = controller.UpdateCourier(0, newEmptyCourier);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteCourierRedirectTest()
        {
            var controller = new CouriersController(_courierService);

            var newCourier = (controller.GetCouriersList().Value as IEnumerable<Courier>).Last();

            var result = controller.DeleteCourier(newCourier.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCouriersList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteCourier(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
