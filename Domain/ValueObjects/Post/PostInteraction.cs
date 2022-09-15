using Social.Domain.Constants;

namespace Social.Domain.ValueObjects.Post
{
   public class PostInteraction
   {
      // interaction identitifer 
      public Guid InteractionId {get; set;}

      // the user who did this interaction
      public Guid UserProfileId {get; set;}
      
      // the post id 
      public Guid PostId { get; set; }
      public InteractionTypes InteractionType {get; set;}
   }
}