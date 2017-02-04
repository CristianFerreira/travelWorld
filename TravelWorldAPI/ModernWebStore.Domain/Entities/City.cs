
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernWebStore.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int idCountry { get; set; }

        public Country Country { get; set; }
    }
}
