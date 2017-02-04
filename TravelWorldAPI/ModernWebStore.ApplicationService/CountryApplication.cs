using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace ModernWebStore.ApplicationService
{
    public class CountryApplication : ApplicationService, ICountryApplicationService
    {
        private ICountryRepository _repository;


        public CountryApplication(ICountryRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Country Create(Country country)
        {         
            _repository.Create(country);
            if (Commit())
               return country;

            return null;
        }

        public Country Delete(int id)
        {
            var country = _repository.Get(id);
            _repository.Delete(country);

            if (Commit())
                return country;

            return null;
        }

        public List<Country> DeleteAlot(List<Country> countries)
        {
            var listCountry = new List<Country>();
            foreach (var country in countries)
            {
                var countryDelete = _repository.Get(country.Id);
                _repository.Delete(countryDelete);

                if (Commit())
                    listCountry.Add(countryDelete);
                else
                    return null;
            }

            return listCountry;
        }


        public List<Country> Get()
        {
            return _repository.Get();
        }

        public Country Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Country> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Country Update(Country country)
        {
            _repository.Update(country);

            if (Commit())
                return country;

            return null;
        }
    }
}
