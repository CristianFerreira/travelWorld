using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModernWebStore.Infra.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private StoreDataContext _context;

        public CommentRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public List<Comment> Get()
        {
            return _context.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> GetByPostId(int id)
        {
            return _context.Comments.Include(c => c.Comments).Where(c => c.Id == 2).ToList();
        }

        public List<Comment> Get(int skip, int take)
        {
            return _context.Comments
                .OrderBy(x => x.Description)
                .Skip(skip).Take(take).ToList();
        }

        public void Update(Comment comment)
        {
            _context.Entry(comment)
                .State = System.Data.Entity.EntityState.Modified;
        }
    }
}
