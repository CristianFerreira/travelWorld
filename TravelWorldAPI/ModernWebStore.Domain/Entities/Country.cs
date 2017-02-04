using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernWebStore.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string name { get; set; }

        public int idContinent { get; set; }
        public Continent continent { get; set; }

        public virtual ICollection<City> cities { get; set; }
    }
}
