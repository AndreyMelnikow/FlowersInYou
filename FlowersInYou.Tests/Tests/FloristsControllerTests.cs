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
    public class FloristsControllerTests
    {
        private IFloristService _floristService = new FloristService(
            new FloristRepository(new FlowersInYouContext()));

        [Fact]
        public void GetFloristsListTest()
        {
            var controller = new FloristsController(_floristService);

            var result = controller.GetFloristsList().Value as IEnumerable<Florist>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Florist>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetFloristTest()
        {
            var controller = new FloristsController(_floristService);

            var result = controller.GetFlorist(1).Value as Florist;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Florist>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateFloristRedirectTest()
        {
            var controller = new FloristsController(_floristService);

            var newFlorist = new Florist
            {
                IsActive = true,
                LastName = "lastname",
                FirstName = "firstname",
                Patronymic = "patronymic",
                PhoneNumber = "88888888888",
                Email = "email@mail.com"
            };

            var result = controller.CreateFlorist(newFlorist);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetFloristsList", redirectToActionResult.ActionName);

            var newEmptyFlorist = new Florist();
            var emptyResult = controller.CreateFlorist(newEmptyFlorist);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void UpdateFloristRedirectTest()
        {
            var controller = new FloristsController(_floristService);

            var newFlorist = (controller.GetFloristsList().Value as IEnumerable<Florist>).Last();
            newFlorist.LastName = "florist";

            var result = controller.UpdateFlorist(newFlorist.Id, newFlorist);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetFloristsList", redirectToActionResult.ActionName);

            var newEmptyFlorist = new Florist();
            var emptyResult = controller.UpdateFlorist(0, newEmptyFlorist);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteFloristRedirectTest()
        {
            var controller = new FloristsController(_floristService);

            var newFlorist = (controller.GetFloristsList().Value as IEnumerable<Florist>).Last();

            var result = controller.DeleteFlorist(newFlorist.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetFloristsList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteFlorist(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
