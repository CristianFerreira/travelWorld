using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernWebStore.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ContinentId { get; set; }
        public Continent Continent { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
