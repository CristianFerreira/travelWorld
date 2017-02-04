
using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface ICountryApplicationService
    {
        List<Country> Get();
        List<Country> Get(int skip, int take);
        Country Get(int id);
        Country Create(Country country);
        Country Update(Country country);
        Country Delete(int id);
        List<Country> DeleteAlot(List<Country> countries);
    }
}
