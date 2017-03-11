using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace ModernWebStore.ApplicationService
{
    public class CityApplication : ApplicationService, ICityApplicationService
    {

        private ICityRepository _repository;


        public CityApplication(ICityRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public City Create(City city)
        {         
            _repository.Create(city);

            if (Commit())
                return city;

            return null;
        }

        public City Delete(int id)
        {
            var city = _repository.Get(id);
            _repository.Delete(city);
            if (Commit())
                return city;

            return null;
        }

        public List<City> DeleteAlot(List<City> cities)
        {
            var listCity = new List<City>();
            foreach (var city in cities)
            {
                var cityDelete = _repository.Get(city.Id);
                _repository.Delete(cityDelete);

                if (Commit())
                    listCity.Add(cityDelete);
                else
                    return null;
            }

            return listCity;
        }


        public List<City> Get()
        {
            return _repository.Get();
        }

        public List<City> GetPostCity()
        {
            return _repository.GetPostCity();
        }

        public City Get(int id)
        {
            return _repository.Get(id);
        }

        public List<City> Get(int skip, int take)
        {
            return  _repository.Get(skip, take);
        }

        public City Update(City city)
        {
            _repository.Update(city);
            if (Commit())
                return city;

            return null;
        }

    }
}
