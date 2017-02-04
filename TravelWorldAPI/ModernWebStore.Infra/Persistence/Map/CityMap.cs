using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infra.Persistence.Map
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            ToTable("City");

            HasKey(x => x.Id);

            Property(x => x.name)
                .HasMaxLength(60)
                .IsRequired();

            HasRequired(x => x.Country);
        }
    }
}
