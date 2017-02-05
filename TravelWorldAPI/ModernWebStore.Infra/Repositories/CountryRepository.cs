using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModernWebStore.Infra.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private StoreDataContext _context;

        public CountryRepository(StoreDataContext context)
        {
             this._context = context;
        }

        public void Create(Country country)
        {
            _context.Countries.Attach(country);
            _context.Countries.Add(country);

        }

        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
        }

        public List<Country> Get()
        {
            return _context.Countries.Include(c => c.Continent).ToList();
        }

        public Country Get(int id)
        {
            return _context.Countries.Include(c => c.Continent).ToList().Find(c => c.Id == id);
        }

        public List<Country> Get(int skip, int take)
        {
            return _context.Countries
                .OrderBy(x => x.Name)
                .Skip(skip).Take(take).ToList();
        }

        public void Update(Country country)
        {
            
            //_context.Countries.Attach(country);
            _context.Entry<Country>(country).State = EntityState.Modified;
        }
    }
}
