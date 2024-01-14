using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowersInYou.Models;
using FlowersInYou.Repositories;
using FlowersInYou.Services;

namespace FlowersInYou.Controllers
{
    public class ConfigurateProductsController : Controller
    {
        private readonly IConfigurateProductService _configurateProductService;

        public ConfigurateProductsController(IConfigurateProductService configurateProductService)
        {
            _configurateProductService = configurateProductService;
        }

        // Вывод записей из таблицы
        public JsonResult GetConfigurateProductsList()
        {
            return Json(_configurateProductService.GetConfigurateProductsList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetConfigurateProduct(int id)
        {
            return Json(_configurateProductService.GetConfigurateProduct(id));
        }

        // Добавление товара в корзину
        [HttpPost]
        [Route("ConfigurateProducts/CreateConfiguration/{clientId}")]
        public IActionResult CreateConfiguration([FromBody] ConfigurateProduct configurateProduct, int clientId)
        {
            bool isCreate = _configurateProductService.CreateConfiguration(configurateProduct, clientId);
            if (isCreate)
            {
                return RedirectToAction(nameof(GetConfigurateProductsList));
            }

            return Json(isCreate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        public IActionResult DeleteConfiguration(int id)
        {
            bool isDelete = _configurateProductService.DeleteConfiguration(id);
            if (isDelete)
            {
                return RedirectToAction(nameof(GetConfigurateProductsList));
            }

            return Json(isDelete);
        }
    }
}
