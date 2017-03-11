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

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Hashtag)
                .HasMaxLength(200);
            

            Property(x => x.Date).IsRequired();
            Property(x => x.Picture).HasMaxLength(100);
            Property(x => x.Text).HasMaxLength(5000);
            Property(x => x.Video).HasMaxLength(200);

            HasRequired(x => x.City);
            HasRequired(x => x.Category);
            HasRequired(x => x.User);
        }    
    }
}

