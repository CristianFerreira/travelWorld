using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace ModernWebStore.ApplicationService
{
    public class PostApplication : ApplicationService, IPostApplicationService
    {
        private IPostRepository _repository;


        public PostApplication(IPostRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Post Create(Post post)
        {
            _repository.Create(post);

            if (Commit())
                return post;

            return null;
        }

        public Post Delete(int id)
        {
            var post = _repository.Get(id);
            _repository.Delete(post);

            if (Commit())
                return post;

            return null;
        }

        public List<Post> DeleteAlot(List<Post> posts)
        {
            var listPost = new List<Post>();
            foreach (var post in posts)
            {
                var postDelete = _repository.Get(post.Id);
                _repository.Delete(postDelete);

                if (Commit())
                    listPost.Add(postDelete);
                else
                    return null;
            }

            return listPost;
        }

        public List<Post> Get()
        {
            return _repository.Get();
        }

        public Post Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Post> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Post Update(Post post)
        {
            _repository.Update(post);

            if (Commit())
                return post;

            return null;
        }
    }
}
