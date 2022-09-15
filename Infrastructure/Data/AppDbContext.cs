using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Domain.Aggregates.PostAggregate;
using Social.Infrastructure.Configurations;

namespace Social.Infrastructure.Data
{

   public class AppDbContext : IdentityDbContext
   {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
         
      }

      public DbSet<UserProfile> Profiles {get; set;}
      public DbSet<Post> Posts {get; set;}

      //! My Custom Configuration Per Entity  :D 
      protected override void OnModelCreating(ModelBuilder builder)
      {
         // configure the configurations of the PostComment value object
         builder.ApplyConfiguration(
            new PostCommentConfig()
         );

         // configure the configurations of the PostInteraction value object
         builder.ApplyConfiguration(
            new PostInteractionConfig()
         );

         // configure the owner-owned 1-1 relation between the owned entity [BasicInfo] and owner entity [Profile]
         builder.ApplyConfiguration(
            new UserProfileConfig()
         );

         // configure the IdentityUserLogin table to specify its PK which is the UserId
         builder.ApplyConfiguration(
            new IdentityUserLoginConfig()
         );

         // configure the IdentityUserRole table to specify its PK which is the RoleId
         builder.ApplyConfiguration(
            new IdentityUserRoleConfig()
         );

         // configure the IdentityUserToken table to specify that its a keyless entity
         builder.ApplyConfiguration(
            new IdentityUserTokenConfig()
         );
      }
   }
}