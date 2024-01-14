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
    public class ConfigurateProductsControllerTests
    {
        private IConfigurateProductService _configurateProductService = new ConfigurateProductService(
            new ConfigurateProductRepository(new FlowersInYouContext()), 
            new BusketRepository(new FlowersInYouContext()));

        [Fact]
        public void GetConfigurateProductsListTest()
        {
            var controller = new ConfigurateProductsController(_configurateProductService);

            var result = controller.GetConfigurateProductsList().Value as IEnumerable<ConfigurateProduct>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<ConfigurateProduct>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetConfigurateProductTest()
        {
            var controller = new ConfigurateProductsController(_configurateProductService);

            var result = controller.GetConfigurateProduct(1).Value as ConfigurateProduct;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<ConfigurateProduct>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateConfigurateProductRedirectTest()
        {
            var controller = new ConfigurateProductsController(_configurateProductService);

            var newConfigurateProduct = new ConfigurateProduct
            {
                IdProduct = 1,
                Price = 1000,
            };

            var result = controller.CreateConfiguration(newConfigurateProduct, 2);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetConfigurateProductsList", redirectToActionResult.ActionName);

            var newEmptyConfigurateProduct = new ConfigurateProduct();
            var emptyResult = controller.CreateConfiguration(newEmptyConfigurateProduct, 2);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteConfigurateProductRedirectTest()
        {
            var controller = new ConfigurateProductsController(_configurateProductService);

            var newConfigurateProduct = (controller.GetConfigurateProductsList().Value as IEnumerable<ConfigurateProduct>).Last();

            var result = controller.DeleteConfiguration(newConfigurateProduct.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetConfigurateProductsList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteConfiguration(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
