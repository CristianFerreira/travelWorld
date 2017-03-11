using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infra.Persistence.Map
{
    class SomeCommentsMap : EntityTypeConfiguration<SomeComments>
    {
        public SomeCommentsMap()
        {
            ToTable("SomeComments");

            HasKey(x => x.Id);

            Property(x => x.Date)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            HasRequired(x => x.Comment);

     

        }
    }
}
