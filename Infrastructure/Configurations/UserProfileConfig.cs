using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.Aggregates.UserProfileAggregate;

namespace Social.Infrastructure.Configurations
{
   public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
   {
      public void Configure(EntityTypeBuilder<UserProfile> builder)
      {
         // the basic info is an owned entity object which has the Profile entity as its owner
         builder.OwnsOne(P => P.BasicInfo);
      }
   }
}