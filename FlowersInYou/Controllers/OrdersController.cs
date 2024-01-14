using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowersInYou;
using FlowersInYou.Services;
using FlowersInYou.Models;
using FlowersInYou.Repositories;

namespace FlowersInYou.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Вывод записей из таблицы
        public JsonResult GetOrdersList()
        {
            return Json(_orderService.GetOrdersList());
        }

        //Информация о заказе для бота
        public JsonResult GetUnacceptedOrderInfo()
        {
            return Json(_orderService.GetUnacceptedOrderInfo());
        }

        // Вывод данных о заказах, которые не приняты
        public JsonResult GetUnacceptedOrders()
        {
            return Json(_orderService.GetUnacceptedOrders());
        }

        // Вывод количества заказов
        public JsonResult GetOrdersCount()
        {
            return Json(_orderService.GetOrdersCount());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetOrder(int id)
        {
            return Json(_orderService.GetOrder(id));
        }

        // Добавление записи в таблицу
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order, int clientId)
        {
            bool isCreate = _orderService.CreateOrder(order, clientId);
            if (isCreate) 
            {
                return RedirectToAction(nameof(GetOrdersList));
            }

            return Json(isCreate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        public IActionResult DeleteOrder(int id)
        {
            bool isDlete = _orderService.DeleteOrder(id);
            if (isDlete)
            {
                return RedirectToAction(nameof(GetOrdersList));
            }

            return Json(isDlete);
        }
    }
}
