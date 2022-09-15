using Social.Domain.Constants;

namespace Social.Domain.ValueObjects.Post
{
   public class PostInteraction
   {
      private PostInteraction()
      {     }
      // interaction identitifer 
      public Guid InteractionId {get; private set;}

      // the user who did this interaction
      public Guid UserProfileId {get; private set;}
      
      // the post id 
      public Guid PostId { get; private set; }
      public InteractionTypes InteractionType {get; private set;}

      //! factory method
      public static PostInteraction Create( Guid postId,  Guid userProfileId, InteractionTypes interactionType)
      {
         return new PostInteraction
         {
            PostId = postId,
            UserProfileId = userProfileId,
            InteractionType = interactionType
         };
      }

   }
}