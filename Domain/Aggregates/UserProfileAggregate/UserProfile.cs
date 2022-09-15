using Social.Domain.ValueObjects.UserProfile;
namespace Social.Domain.Aggregates.UserProfileAggregate
{
   public class UserProfile
   {
      // Private constructor to prevent any consumer from creating an instance of this class
      private UserProfile()
      {  }
      // the identifier of this view of user profile 
      public Guid UserProfileId { get; private set; }

      // the identifier of the user identity 
      public string IdentityId { get; private set; } // FK for identity id 
      
      // the basic info of the user profile
      public BasicInfo BasicInfo {get; private set;} 
      // keep track of time when this user is created and last modified
      public DateTime CreatedAt {get; private set;}
      public DateTime LastModified {get; private set;}

      //! Factory method
      public static UserProfile Create(string identityId, BasicInfo basicInfo)
      {
         return new UserProfile
         {
            IdentityId = identityId,
            BasicInfo = basicInfo,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow
         };
      }

      //! Method to update the profile basic info
      public void UpdateProfile(BasicInfo basicInfo)
      {
         BasicInfo = basicInfo;
         LastModified = DateTime.UtcNow;
      }
   }
}