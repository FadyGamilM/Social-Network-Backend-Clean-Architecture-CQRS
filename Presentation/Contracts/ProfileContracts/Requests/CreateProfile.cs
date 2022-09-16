namespace Social.Presentation.Contracts.ProfileContracts.Requests
{
   // contracts are just a data containrs, so we can go with records not classes
   public record CreateProfile
   {
      public string FirstName { get; set; }
      public string LastName {get; set;}  
      public string Email {get; set;}
      public DateTime DateOfBirth {get; set;}
      public string Phone { get; set; }
      public string CurrentCity {get; set;}   
   }
}