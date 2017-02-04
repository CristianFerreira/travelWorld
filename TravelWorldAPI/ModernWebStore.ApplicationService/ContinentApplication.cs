using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace ModernWebStore.ApplicationService
{
    public class ContinentApplication : ApplicationService, IContinentApplicationService
    {
        private IContinentRepository _repository;


        public ContinentApplication(IContinentRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Continent Create(Continent continent)
        {
            _repository.Create(continent);

            if (Commit())
                return continent;

            return null;
        }

        public Continent Delete(int id)
        {
            var continent = _repository.Get(id);
            _repository.Delete(continent);

            if (Commit())
                return continent;

            return null;
        }

        public List<Continent> DeleteAlot(List<Continent> continents)
        {
            var listContinent = new List<Continent>();
            foreach (var continent in continents)
            {
                var continentDelete = _repository.Get(continent.Id);
                _repository.Delete(continentDelete);

                if (Commit())
                    listContinent.Add(continentDelete);
                else
                    return null;
            }

            return listContinent;
        }

        public List<Continent> Get()
        {
            return _repository.Get();
        }

        public Continent Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Continent> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }


        public Continent Update(Continent continent)
        {
            _repository.Update(continent);

            if (Commit())
                return continent;

            return null;
        }
     
    }
}
