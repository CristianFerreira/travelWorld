using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infra.Persistence.Map
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            ToTable("Country");

            HasKey(x => x.Id);

            Property(x => x.name)
                .HasMaxLength(60)
                .IsRequired();

            HasRequired(x => x.continent);

            HasMany(x => x.cities);

        }
    }
}
