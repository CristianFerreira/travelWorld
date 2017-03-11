using ModernWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Domain.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> Get();
        List<Comment> Get(int skip, int take);
        List<Comment> GetByPostId(int id);
        Comment Get(int id);
        void Create(Comment post);
        void Update(Comment post);
        void Delete(Comment post);
    }
}
