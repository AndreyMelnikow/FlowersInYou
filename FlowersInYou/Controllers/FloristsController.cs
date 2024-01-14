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
    public class FloristsController : Controller
    {
        private readonly IFloristService _floristService;

        public FloristsController(IFloristService floristService)
        {
            _floristService = floristService;
        }

        // Вывод записей из таблицы
        public JsonResult GetFloristsList()
        {
            return Json(_floristService.GetFloristsList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetFlorist(int id)
        {
            return Json(_floristService.GetFlorist(id));
        }

        // Добавление записи в таблицу
        [HttpPost]
        public IActionResult CreateFlorist([FromBody] Florist florist)
        {
            bool isCreate = _floristService.CreateFlorist(florist);
            if (isCreate) 
            {
                return RedirectToAction(nameof(GetFloristsList));
            }

            return Json(isCreate);
        }

        // Изменение записи в таблице
        [HttpPost]
        public IActionResult UpdateFlorist(int id, [FromBody] Florist florist)
        {
            bool isUpdate = _floristService.UpdateFlorist(id, florist);
            if (isUpdate)
            {
                return RedirectToAction(nameof(GetFloristsList));
            }

            return Json(isUpdate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFlorist(int id)
        {
            bool isDelete = _floristService.DeleteFlorist(id);
            if (isDelete)
            {
                return RedirectToAction(nameof(GetFloristsList));
            }

            return Json(isDelete);
        }
    }
}
