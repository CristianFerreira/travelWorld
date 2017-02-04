
using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface ICityApplicationService
    {
        List<City> Get();
        List<City> Get(int skip, int take);
        City Get(int id);
        City Create(City city);
        City Update(City city);
        City Delete(int id);
        List<City> DeleteAlot(List<City> cities);
    }
}
