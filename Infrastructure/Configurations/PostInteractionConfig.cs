using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.ValueObjects.Post;

namespace Social.Infrastructure.Configurations
{
   public class PostInteractionConfig : IEntityTypeConfiguration<PostInteraction>
   {
      public void Configure(EntityTypeBuilder<PostInteraction> builder)
      {
         // identify the pk of this object in db
         builder.HasKey(PI => PI.InteractionId);
      }
   }
}