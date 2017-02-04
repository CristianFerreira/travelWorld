using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infra.Persistence.Map
{
    class PostMap : EntityTypeConfiguration<Post>
    {

        public PostMap()
        {
            ToTable("Post");

            HasKey(x => x.Id);

            Property(x => x.title)
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.description)
                .HasMaxLength(2000)
                .IsRequired();

            Property(x => x.date).IsRequired();
            Property(x => x.txtPicture).HasMaxLength(100);
            Property(x => x.picture).HasMaxLength(200);
            Property(x => x.video).HasMaxLength(200);

            HasRequired(x => x.continent);
            HasRequired(x => x.category);
            HasRequired(x => x.users);
        }    
    }
}

