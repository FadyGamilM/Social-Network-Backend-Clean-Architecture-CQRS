using System.Net.Mime;
namespace Social.Domain.ValueObjects.Post
{
   public class PostComment
   {
      private PostComment()
      {     }
      // comment identifier
      public Guid CommentId { get; private set; }

      // FK of the post id [1_post - N_Comments] relation so put the pk of post as fk into comment
      public Guid PostId {get; private set;} 

      public string CommentContent {get; private set;}

      // the user who commented this comment
      public Guid UserProfileId {get; private set;}
      public DateTime CreatedAt {get; private set;}
      public DateTime LastModified {get; private set;}

      //! factory method
      public static PostComment Create(Guid postId, Guid userProfileId, string commentContent)
      {
         return new PostComment
         {
            PostId = postId,
            UserProfileId = userProfileId,
            CommentContent = commentContent,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow
         };
      }

      //! Update the comment content
      public void UpdateComment (string commentContent)
      {
         CommentContent = commentContent;
         LastModified = DateTime.UtcNow;
      }
   }
}