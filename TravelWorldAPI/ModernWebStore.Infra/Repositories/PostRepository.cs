using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using System.Data.Entity;
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

            post.UserId = 1;
            _context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
        }

        public List<Post> Get()
        {
            return _context.Posts.Include(p => p.User).Include(p => p.Category).Include(p => p.City).ToList();
        }

        public Post Get(int id)
        {
            return _context.Posts.Include(p => p.User).Include(p => p.Category)
                    .Include(p => p.City).ToList().Find(p => p.Id == id);
        }

        public List<Post> BuscarPorCategoria(string categoria)
        {
            return _context.Posts.Include(p => p.User).Include(p => p.Category).Include(p => p.City)
                    .Where(p => p.Category.Name == categoria).ToList();
        }

        public List<Post> BuscarPorCity(string city)
        {
            return _context.Posts.Include(p => p.User).Include(p => p.Category).Include(p => p.City)
                    .Where(p => p.City.Name == city).ToList();
        }

        public List<Post> Get(int skip, int take)
        {
            return _context.Posts
                 .OrderBy(x => x.Date)
                 .Skip(skip).Take(take).ToList();
        }

        public void Update(Post post)
        {
            post.UserId = 1;
            _context.Entry<Post>(post)
                .State = EntityState.Modified;
        }
    }
}
