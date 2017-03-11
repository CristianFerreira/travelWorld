using ModernWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Domain.Services
{
    public interface ICommentApplicationService
    {
        List<Comment> Get();
        List<Comment> Get(int skip, int take);
        Comment Get(int id);
        List<Comment> GetByPostId(int id);
        Comment Create(Comment post);
        Comment Update(Comment post);
        Comment Delete(int id);
        List<Comment> DeleteAlot(List<Comment> posts);
    }
}
