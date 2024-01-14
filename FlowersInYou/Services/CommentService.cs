using FlowersInYou.Models;
using FlowersInYou.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace FlowersInYou.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetCommentsList();
        Comment GetComment(int id);
        IEnumerable<Comment> GetProductComments(int idProduct);
        bool CreateComment(Comment client);
        bool UpdateComment(int id, Comment comment);
        bool DeleteComment(int id);
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> GetCommentsList()
        {
            return _commentRepository.GetCommentsList();
        }

        public Comment GetComment(int id)
        {
            return _commentRepository.GetComment(id);
        }

        public IEnumerable<Comment> GetProductComments(int idProduct) 
        {
            return _commentRepository.GetProductComments(idProduct);
        }

        public bool CreateComment(Comment comment)
        {
            return _commentRepository.CreateComment(comment);
        }

        public bool UpdateComment(int id, Comment comment)
        {
            return _commentRepository.UpdateComment(id, comment);
        }

        public bool DeleteComment(int id)
        {
            return _commentRepository.DeleteComment(id);
        }
    }
}
