using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModernWebStore.Infra.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private StoreDataContext _context;

        public ContinentRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(Continent continent)
        {
            //_context.Continents.Attach(continent);
            _context.Continents.Add(continent);
        }

        public void Delete(Continent continent)
        {
            _context.Continents.Remove(continent);
        }

        public List<Continent> Get()
        {
            return _context.Continents.Include(c => c.Countries).ToList();
        }

        public Continent Get(int id)
        {
            return _context.Continents.Find(id);
        }

        public List<Continent> Get(int skip, int take)
        {
             return _context.Continents
                 .OrderBy(x => x.Name)
                 .Skip(skip).Take(take).ToList();
        }

        public void Update(Continent continent)
        {
            _context.Continents.Attach(continent);
            _context.Entry(continent)
                .State = System.Data.Entity.EntityState.Modified;
        }
    }
}
