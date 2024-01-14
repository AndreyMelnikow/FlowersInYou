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
    public class MaterialsController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        // Вывод записей из таблицы
        public JsonResult GetMaterialsList()
        {
            return Json(_materialService.GetMaterialList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetMaterial(int id)
        {
            return Json(_materialService.GetMaterial(id));
        }
    }
}
