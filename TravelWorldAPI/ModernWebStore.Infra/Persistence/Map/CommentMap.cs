using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infra.Persistence.Map
{
    class CommentMap : EntityTypeConfiguration<Comment> 
    {
         public CommentMap()
         {
            ToTable("Comment");

            HasKey(x => x.Id);

            Property(x => x.Date)
                .IsRequired();

            Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            HasMany(x => x.Comments)
               .WithRequired(x => x.Comment);
        }
    }

}
