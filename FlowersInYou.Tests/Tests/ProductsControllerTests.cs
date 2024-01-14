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
    public class ProductsControllerTests
    {
        private IProductService _productService = new ProductService(
            new ProductRepository(new FlowersInYouContext()));

        [Fact]
        public void GetProductsListTest()
        {
            var controller = new ProductsController(_productService);

            var result = controller.GetProductsList().Value as IEnumerable<Product>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetProductTest()
        {
            var controller = new ProductsController(_productService);

            var result = controller.GetProduct(1).Value as Product;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Product>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetProductsProductType()
        {
            var controller = new ProductsController(_productService);

            var result = controller.GetProductsProductType(2).Value as IEnumerable<object>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<object>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateProductRedirectTest()
        {
            var controller = new ProductsController(_productService);

            var newProduct = new Product
            {
                Name = "name",
                Count = 5,
                Description = "description",
                IdProductType = 1,
                ShortDescription = "desc",
                StartPrice = 599,
            };

            var result = controller.CreateProduct(newProduct);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetProductsList", redirectToActionResult.ActionName);

            var newEmptyProduct = new Product();
            var emptyResult = controller.CreateProduct(newEmptyProduct);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void UpdateProductRedirectTest()
        {
            var controller = new ProductsController(_productService);

            var newProduct = (controller.GetProductsList().Value as IEnumerable<Product>).Last();
            newProduct.Count = 10;

            var result = controller.UpdateProduct(newProduct.Id, newProduct);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetProductsList", redirectToActionResult.ActionName);

            var newEmptyProduct = new Product();
            var emptyResult = controller.UpdateProduct(0, newEmptyProduct);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteProductRedirectTest()
        {
            var controller = new ProductsController(_productService);

            var newProduct = (controller.GetProductsList().Value as IEnumerable<Product>).Last();

            var result = controller.DeleteProduct(newProduct.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetProductsList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteProduct(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
