

using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface IPostApplicationService
    {
        List<Post> Get();
        List<Post> Get(int skip, int take);
        Post Get(int id);
        void Create(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
