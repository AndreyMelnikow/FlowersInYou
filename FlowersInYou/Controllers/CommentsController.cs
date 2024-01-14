using FlowersInYou.Models;
using FlowersInYou.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlowersInYou.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Вывод записей из таблицы
        public JsonResult GetCommentsList()
        {
            return Json(_commentService.GetCommentsList());
        }

        // Вывод информации об определённой позиции в таблице
        public JsonResult GetComment(int id)
        {
            return Json(_commentService.GetComment(id));
        }

        // Вывод информации о продукте и комментарии, оставленном на этот продукт
        [Route("Comments/GetProductComments/{idProduct}")]
        public JsonResult GetProductComments(int idProduct)
        {
            return Json(_commentService.GetProductComments(idProduct));
        }

        // Добавление записи в таблицу
        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            bool isCreate =_commentService.CreateComment(comment);
            if (isCreate)
            {
                return RedirectToAction(nameof(GetCommentsList));
            }

            return Json(isCreate);
        }

        // Изменение записи в таблице
        [HttpPost]
        public IActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            bool isUpdate = _commentService.UpdateComment(id, comment);
            if (isUpdate)
            {
                return RedirectToAction(nameof(GetCommentsList));
            }

            return Json(isUpdate);
        }

        // Удаление записи из таблицы
        [HttpPost]
        public IActionResult DeleteComment(int id)
        {
            bool isDelete = _commentService.DeleteComment(id);
            if (isDelete)
            {
                return RedirectToAction(nameof(GetCommentsList));
            }

            return Json(isDelete);
        }
    }
}
