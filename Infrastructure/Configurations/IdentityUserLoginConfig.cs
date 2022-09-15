using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Social.Infrastructure.Configurations
{
   public class IdentityUserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<string>>
   {
      public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
      {
         builder.HasKey(IUL => IUL.UserId);
      }
   }
}