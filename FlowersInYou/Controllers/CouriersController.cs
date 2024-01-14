using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowersInYou.Models;
using FlowersInYou.Services;

namespace FlowersInYou.Controllers
{
    public class CouriersController : Controller
    {
        private readonly ICourierService _courierService;

        public CouriersController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        // Вывод записей из таблицы
        public JsonResult GetCouriersList()
        {
            return Json(_courierService.GetCouriersList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetCourier(int id)
        {
            return Json(_courierService.GetCourier(id));
        }

        // Добавление записи в таблицу
        [HttpPost]
        public IActionResult CreateCourier([FromBody] Courier courier)
        {
            bool isCreate = _courierService.CreateCourier(courier);
            if (isCreate)
            {
                return RedirectToAction(nameof(GetCouriersList));
            }

            return Json(isCreate);
        }

        // Изменение записи в таблице
        [HttpPost]
        public IActionResult UpdateCourier(int id, [FromBody] Courier courier)
        {
            bool isUpdate = _courierService.UpdateCourier(id, courier);
            if (isUpdate)
            {
                return RedirectToAction(nameof(GetCouriersList));
            }

            return Json(isUpdate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        public IActionResult DeleteCourier(int id)
        {
            bool isDelete = _courierService.DeleteCourier(id);
            if (isDelete)
            {
                return RedirectToAction(nameof(GetCouriersList));
            }

            return Json(isDelete);
        }
    }
}
