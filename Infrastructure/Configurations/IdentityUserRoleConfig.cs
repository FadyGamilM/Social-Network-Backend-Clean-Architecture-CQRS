using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Social.Infrastructure.Configurations
{
   public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
   {
      public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
      {
         builder.HasKey(IUR => IUR.RoleId);
      }
   }
}