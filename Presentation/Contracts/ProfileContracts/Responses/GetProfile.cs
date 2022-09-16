namespace Social.Presentation.Contracts.ProfileContracts.Responses
{
   public record GetProfile
   {
      public Guid UserProfileId { get; set; }
      public string FirstName { get; set; }
      public string LastName {get; set;}  
      public string Email {get; set;}
      public DateTime DateOfBirth {get; set;}
      public string Phone { get; set; }
      public string CurrentCity {get; set;} 
      public DateTime CreatedAt {get; set;}
      public DateTime LastModified {get; set;}
   }
}