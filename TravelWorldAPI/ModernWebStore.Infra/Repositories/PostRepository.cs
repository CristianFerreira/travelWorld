using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace ModernWebStore.Infra.Repositories
{
    public class PostRepository : IPostRepository
    {
        private StoreDataContext _context;

        public PostRepository(StoreDataContext _context)
        {
             this._context = _context;
        }

        public void Create(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
        }

        public List<Post> Get()
        {
            return _context.Posts.ToList();
        }

        public Post Get(int id)
        {
            return _context.Posts.Find(id);
        }

        public List<Post> Get(int skip, int take)
        {
            return _context.Posts
                 .OrderBy(x => x.Date)
                 .Skip(skip).Take(take).ToList();
        }

        public void Update(Post post)
        {
            _context.Entry<Post>(post)
                .State = System.Data.Entity.EntityState.Modified;
        }
    }
}
