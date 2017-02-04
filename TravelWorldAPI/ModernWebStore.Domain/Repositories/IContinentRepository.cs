using ModernWebStore.Domain.Entities;
using System.Collections.Generic;


namespace ModernWebStore.Domain.Repositories
{
    public interface IContinentRepository
    {
        List<Continent> Get();
        List<Continent> Get(int skip, int take);
        Continent Get(int id);
        void Create(Continent continent);
        void Update(Continent continent);
        void Delete(Continent continent);
    }
}
