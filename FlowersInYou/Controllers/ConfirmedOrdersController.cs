using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowersInYou;
using FlowersInYou.Models;
using FlowersInYou.Repositories;
using FlowersInYou.Services;

namespace FlowersInYou.Controllers
{
    public class ConfirmedOrdersController : Controller
    {
        private readonly IConfirmedOrderService _confirmedOrderService;

        public ConfirmedOrdersController(IConfirmedOrderService confirmedOrderService)
        {
            _confirmedOrderService = confirmedOrderService;
        }

        // Вывод записей из таблицы
        public JsonResult GetConfirmedOrdersList()
        {
            return Json(_confirmedOrderService.GetConfirmedOrderList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetConfirmedOrder(int id)
        {
            return Json(_confirmedOrderService.GetConfirmedOrder(id));
        }

        // Добавление заказа в базу данных и его отправка курьеру и флористу
        [HttpPost]
        [Route("ConfirmedOrders/CreateConfirmedOrder/{courierPhone}&{floristPhone}")]
        public IActionResult CreateConfirmedOrder([FromBody] ConfirmedOrder confirmedOrder, string courierPhone, string floristPhone)
        {
            bool isCreate = _confirmedOrderService.CreateConfirmedOrder(confirmedOrder, courierPhone, floristPhone);
            if (isCreate)
            {
                return RedirectToAction(nameof(GetConfirmedOrdersList));
            }

            return Json(isCreate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        public IActionResult DeleteConfirmedOrder(int id)
        {
            bool isDelete = _confirmedOrderService.DeleteConfirmedOrder(id);
            if (isDelete)
            {
                return RedirectToAction(nameof(GetConfirmedOrdersList));
            }

            return Json(isDelete);
        }
    }
}
