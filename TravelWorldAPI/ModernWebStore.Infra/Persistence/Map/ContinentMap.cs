﻿using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infra.Persistence.Map
{
    public class ContinentMap : EntityTypeConfiguration<Continent>
    {
        public ContinentMap()
        {
            ToTable("Continent");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(60)
                .IsRequired();

            HasMany(x => x.Countries)
                .WithRequired(x => x.Continent);

        }
    }
}
