

using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface IContinentApplicationService
    {
        List<Continent> Get();
        List<Continent> Get(int skip, int take);
        Continent Get(int id);
        Continent Create(Continent continent);
        Continent Update(Continent continent);
        Continent Delete(int id);
        List<Continent> DeleteAlot(List<Continent> continent);
    }
}
