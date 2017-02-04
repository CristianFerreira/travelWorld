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

        public void Create(Post post)
        {
            _repository.Create(post);
        }

        public void Delete(Post post)
        {
            _repository.Delete(post);
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

        public void Update(Post post)
        {
            _repository.Update(post);
        }
    }
}
