using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Domain.Constants;
using Social.Domain.ValueObjects.Post;
namespace Social.Domain.Aggregates.PostAggregate
{
   public class Post 
   {
      //! Private Constructor which disable the creation of this Post without the factory method we have enabled 
      private Post()
      {   }
      
      // entity identifier of the post 
      public Guid PostId {get; private set;}

      // the id of the owner of this post
      public Guid UserProfileId {get; private set;}

      // reference relation 
      public UserProfile UserProfile {get; private set;}

      // the content of the post, we keep it as text only for now without media
      public string TextContent {get; private set;}

      // list of comments related to each post
      private readonly List<PostComment> _Comments = new List<PostComment>();
      public IEnumerable<PostComment> Comments {get { return _Comments; }}

      // lsit of interactions and emojs
      private readonly List<PostInteraction> _Interactions = new List<PostInteraction>();
      public IEnumerable<PostInteraction> Interactions {get {return _Interactions;}}
      public DateTime CreatedAt {get; private set;}
      public DateTime LastModified {get; private set;}
   
      //! Facotry Method to provide the external layers the ability to create a new post without any invariant possiblities [Encapsulation]
      public static Post Create(Guid userProfileId, string textContent)
      {
         // create the new post object
         var newPost = new Post 
         {
            UserProfileId = userProfileId,
            TextContent = textContent,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow
         };
         // return to the consumer class
         return newPost;
      }

      //! To update a post, the only way is to used to methods that are provided by the aggregate itself
      public void UpdatePost (string textContent)
      {
         TextContent = textContent;
         // the alst modified date should be updated now
         LastModified = DateTime.UtcNow;
      }

      //! To add a new comment for an existing post
      public void AddComment (PostComment comment)
      {
         _Comments.Add(comment);
      }

      //! To delete a comment for an existing post
      public void RemoveComment (PostComment comment)
      {
         _Comments.Remove(comment);
      }

      //! To add a new interaction to an existing post
      public void AddInteraction (PostInteraction interaction)
      {
         _Interactions.Add(interaction);
      }

      //! To remove an interaction from the post
      public void RemoveInteraction (PostInteraction interaction)
      {
         _Interactions.Remove(interaction);
      }
   }
}