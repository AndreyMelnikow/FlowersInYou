using FlowersInYou.Models;
using FlowersInYou.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersInYou.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Вывод записей из таблицы
        public JsonResult GetProductsList()
        {
            return Json(_productService.GetProductsList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetProduct(int id)
        {
            return Json(_productService.GetProduct(id));
        }

        // Вывод информации продуктах определённого типа
        [Route("Products/GetProductsProductType/{idProductType}")]
        public JsonResult GetProductsProductType(int idProductType)
        {
            return Json(_productService.GetProductsProductType(idProductType));
        }

        // Добавление записи в таблицу
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            bool isCreate = _productService.CreateProduct(product);
            if (isCreate) 
            {
                return RedirectToAction(nameof(GetProductsList));
            }

            return Json(isCreate);
        }

        // Изменение записи в таблице
        [HttpPost]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            bool isUpdate = _productService.UpdateProduct(id, product);
            if (isUpdate)
            {
                return RedirectToAction(nameof(GetProductsList));
            }

            return Json(isUpdate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            bool isDelete = _productService.DeleteProduct(id);
            if (isDelete)
            {
                return RedirectToAction(nameof(GetProductsList));
            }

            return Json(isDelete);
        }
    }
}
