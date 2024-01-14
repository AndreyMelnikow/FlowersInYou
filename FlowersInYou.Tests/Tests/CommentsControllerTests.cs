using FlowersInYou.Controllers;
using FlowersInYou.Models;
using FlowersInYou.Repositories;
using FlowersInYou.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersInYou.Tests.Tests
{
    public class CommentsControllerTests
    {
        private ICommentService _commentService = new CommentService(
            new CommentRepository(new FlowersInYouContext()));

        [Fact]
        public void GetCommentsListTest()
        {
            var controller = new CommentsController(_commentService);

            var result = controller.GetCommentsList().Value as IEnumerable<Comment>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Comment>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetCommentTest()
        {
            var controller = new CommentsController(_commentService);

            var result = controller.GetComment(1).Value as Comment;

            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<Comment>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void GetProductCommentsTest()
        {
            var controller = new CommentsController(_commentService);

            var result = controller.GetProductComments(1).Value as IEnumerable<Comment>;

            Assert.NotEmpty(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Comment>>(result);
            Assert.Equal(result, model);
        }

        [Fact]
        public void CreateCommentRedirectTest()
        {
            var controller = new CommentsController(_commentService);

            var newComment = new Comment
            {
                Rate = 5,
                Text = "text",
                IdClient = 2,
                IdProduct = 1,
            };

            var result = controller.CreateComment(newComment);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCommentsList", redirectToActionResult.ActionName);

            var newEmptyComment = new Comment();
            var emptyResult = controller.CreateComment(newEmptyComment);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void UpdateCommentRedirectTest()
        {
            var controller = new CommentsController(_commentService);

            var newComment = (controller.GetCommentsList().Value as IEnumerable<Comment>).Last();
            newComment.Text = "comment";

            var result = controller.UpdateComment(newComment.Id, newComment);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCommentsList", redirectToActionResult.ActionName);

            var newEmptyComment = new Comment();
            var emptyResult = controller.UpdateComment(0, newEmptyComment);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }

        [Fact]
        public void DeleteCommentRedirectTest()
        {
            var controller = new CommentsController(_commentService);

            var newComment = (controller.GetCommentsList().Value as IEnumerable<Comment>).Last();

            var result = controller.DeleteComment(newComment.Id);

            Assert.NotNull(result);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCommentsList", redirectToActionResult.ActionName);

            var emptyResult = controller.DeleteComment(0);

            Assert.NotNull(emptyResult);
            var jsonResult = Assert.IsType<JsonResult>(emptyResult);
            Assert.Equal(false, jsonResult.Value);
        }
    }
}
