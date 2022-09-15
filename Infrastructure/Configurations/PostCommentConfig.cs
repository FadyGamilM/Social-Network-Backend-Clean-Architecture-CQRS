using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.ValueObjects.Post;

namespace Social.Infrastructure.Configurations
{
   internal class PostCommentConfig : IEntityTypeConfiguration<PostComment>
   {
      public void Configure(EntityTypeBuilder<PostComment> builder)
      {
         // we need to identify the primary key of the PostComment object
         builder.HasKey(PC=>PC.CommentId);
      }
   }
}