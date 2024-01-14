
using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsList();
        Comment GetComment(int id);
        bool CreateComment(Comment comment);
        bool UpdateComment(int id, Comment comment);
        bool DeleteComment(int id);
        IEnumerable<Comment> GetProductComments(int productId);
    }

    public class CommentRepository : ICommentRepository
    {
        private FlowersInYouContext _context;

        public CommentRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetCommentsList()
        {
            return _context.Comment.ToList();
        }

        public Comment GetComment(int id)
        {
            return _context.Comment.Find(id);
        }

        public IEnumerable<Comment> GetProductComments(int productId)
        {
            return _context.Comment.Where(p => p.IdProduct == productId).ToList();
        }

        public bool CreateComment(Comment comment)
        {
            if (comment != null)
            {
                try
                {
                    _context.Add(comment);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public bool UpdateComment(int id, Comment comment)
        {
            if (comment != null)
            {
                try
                {
                    _context.Comment.Update(comment);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public bool DeleteComment(int id)
        {
            Comment comment = GetComment(id);

            if (comment != null)
            {
                try
                {
                    _context.Comment.Remove(comment);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return false;
                }
            }

            return false;
        }
    }
}
