using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModernWebStore.Infra.Repositories
{
    public class CityRepository : ICityRepository
    {
        private StoreDataContext _context;

        public CityRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(City city)
        {
            city.Country = null;
            _context.Cities.Add(city);   
        }

        public void Delete(City city)
        {
            _context.Cities.Remove(city);
        }

        public List<City> Get()
        {
            return _context.Cities.Include(c => c.Country.Continent).ToList();
        }


        public List<City> GetPostCity()
        {
            return _context.Cities.Include(c => c.Country.Continent).ToList();
        }
      

        public City Get(int id)
        {
            return _context.Cities.Include(c => c.Country.Continent).ToList().Find(c => c.Id == id);
        }

        public List<City> Get(int skip, int take)
        {
            return _context.Cities
               .OrderBy(x => x.Name)
               .Skip(skip).Take(take).ToList();
        }

        public void Update(City city)
        {
            city.Country = null;
            _context.Entry(city)
                 .State = EntityState.Modified;
        }
    }
}
