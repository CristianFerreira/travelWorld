using ModernWebStore.Domain.Entities;
using System.Collections.Generic;


namespace ModernWebStore.Domain.Repositories
{
    public interface ICountryRepository
    {
        List<Country> Get();
        List<Country> Get(int skip, int take);
        Country Get(int id);
        void Create(Country country);
        void Update(Country country);
        void Delete(Country country);
    }
}
