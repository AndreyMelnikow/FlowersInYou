using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowersInYou;
using FlowersInYou.Services;

namespace FlowersInYou.Controllers
{
    public class SizesController : Controller
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        // Вывод записей из таблицы
        public JsonResult GetSizesList()
        {
            return Json(_sizeService.GetSizesList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetSize(int id)
        {
            return Json(_sizeService.GetSize(id));
        }
    }
}
