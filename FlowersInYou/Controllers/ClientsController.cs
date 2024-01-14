using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowersInYou.Services;
using FlowersInYou.Models;

namespace FlowersInYou.Controllers
{
    public class ClientsController : Controller
    {
        private IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // Вывод записей из таблицы
        public JsonResult GetClientsList()
        {
            return Json( _clientService.GetClientsList());
        }

        public JsonResult GetClient(int id)
        {
            return Json(_clientService.GetClient(id));
        }

        // Регистрация
        [HttpPost]
        public IActionResult CreateClient([FromBody] Client client)
        {
            bool isCreate = _clientService.CreateClient(client);
            if (isCreate)
            {
                return RedirectToAction(nameof(GetClientsList));
            }

            return Json(isCreate);
        }

        // Изменение записи в таблице
        [HttpPost]
        public IActionResult UpdateClient(int id, [FromBody] Client client)
        {
            bool isUpdate = _clientService.UpdateClient(id, client);
            if (isUpdate)
            {
                return RedirectToAction(nameof(GetClientsList));
            }

            return Json(isUpdate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        public IActionResult DeleteClient(int id)
        {
            bool isDelete = _clientService.DeleteClient(id);
            if (isDelete)
            {
                return RedirectToAction(nameof(GetClientsList));
            }

            return Json(isDelete);
        }
    }
}
