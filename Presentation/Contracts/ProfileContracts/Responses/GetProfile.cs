namespace Social.Presentation.Contracts.ProfileContracts.Responses
{
   public record GetProfile
   {
      public Guid UserProfileId { get; set; }
      public BasicInfo BasicInfo {get; set;}
      public DateTime CreatedAt {get; set;}
      public DateTime LastModified {get; set;}
   }
}