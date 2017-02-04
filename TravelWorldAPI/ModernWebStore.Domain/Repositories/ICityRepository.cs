using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Repositories
{
    public interface ICityRepository
    {
        List<City> Get();
        List<City> Get(int skip, int take);
        City Get(int id);
        void Create(City city);
        void Update(City city);
        void Delete(City city);
    }
}
