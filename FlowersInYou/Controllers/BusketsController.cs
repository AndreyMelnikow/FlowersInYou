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
    public class BusketsController : Controller
    {
        private readonly IBusketService _busketService;

        public BusketsController(IBusketService busketService)
        {
            _busketService = busketService;
        }

        // Вывод общей стоимости товаров корзины определённого клиента
        [Route("Buskets/GetFullAmount/{clientId}")]
        public JsonResult GetFullAmount(int clientId)
        {
            return Json(_busketService.GetFullAmount(clientId));
        }

        // Вывод всех записей 
        public JsonResult GetBusketList()
        {
            return Json(_busketService.GetBusketList());
        }
    }
}
