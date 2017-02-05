

using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface IPostApplicationService
    {
        List<Post> Get();
        List<Post> Get(int skip, int take);
        Post Get(int id);
        Post Create(Post post);
        Post Update(Post post);
        Post Delete(int id);
        List<Post> DeleteAlot(List<Post> posts);
    }
}
