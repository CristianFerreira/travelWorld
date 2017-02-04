using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace ModernWebStore.ApplicationService
{
    public class CategoryApplication : ApplicationService, ICategoryApplicationService
    {
        private ICategoryRepository _repository;

        public CategoryApplication(ICategoryRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Category Create(Category category)
        {
            category.Register();
            _repository.Create(category);

            if (Commit())
                return category;

            return null;
        }

        public Category Delete(int id)
        {
            var category = _repository.Get(id);
            _repository.Delete(category);

            if (Commit())
                return category;

            return null;
        }

        public List<Category> DeleteAlot(List<Category> categories)
        {
            var listCategories = new List<Category>();
            foreach (var category in categories)
            {
                var categoryDelete = _repository.Get(category.Id);
                _repository.Delete(categoryDelete);

                if (Commit())
                    listCategories.Add(categoryDelete);
                else
                    return null;
            }

            return listCategories;
        }

        public List<Category> Get()
        {
            return _repository.Get();
        }

        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Category> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Category Update(Category category)
        {
            category.Register();
            _repository.Update(category);

            if (Commit())
                return category;

            return null;

        }

    }
}
