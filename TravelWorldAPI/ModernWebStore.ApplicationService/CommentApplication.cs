using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.ApplicationService
{
    public class CommentApplication : ApplicationService, ICommentApplicationService
    {

        private ICommentRepository _repository;


        public CommentApplication(ICommentRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Comment Create(Comment comment)
        {
            comment.Date = DateTime.Now;
            _repository.Create(comment);

            if (Commit())
                return comment;

            return null;
        }

        public Comment Delete(int id)
        {
            var comment = _repository.Get(id);
            _repository.Delete(comment);
            if (Commit())
                return comment;

            return null;
        }

        public List<Comment> DeleteAlot(List<Comment> comments)
        {
            var listComments = new List<Comment>();
            foreach (var comment in comments)
            {
                var commentDelete = _repository.Get(comment.Id);
                _repository.Delete(commentDelete);

                if (Commit())
                    listComments.Add(commentDelete);
                else
                    return null;
            }

            return listComments;
        }


        public List<Comment> Get()
        {
            return _repository.Get();
        }

        public Comment Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Comment> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public List<Comment> GetByPostId(int id)
        {
            return _repository.GetByPostId(id);
        }

        public Comment Update(Comment comment)
        {
            _repository.Update(comment);
            if (Commit())
                return comment;

            return null;
        }

    }
}
