namespace Social.Domain.ValueObjects.Post
{
   public class PostComment
   {
      // comment identifier
      public Guid CommentId { get; set; }

      // FK of the post id [1_post - N_Comments] relation so put the pk of post as fk into comment
      public Guid PostId {get; set;} 

      public string commentContent {get; set;}

      // the user who commented this comment
      public Guid UserProfileId {get; set;}
      public DateTime CreatedAt {get; set;}
      public DateTime LastMOdified {get; set;}
   }
}