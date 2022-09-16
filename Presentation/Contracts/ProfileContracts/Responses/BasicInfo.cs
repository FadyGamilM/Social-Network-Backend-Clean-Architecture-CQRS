namespace Social.Presentation.Contracts.ProfileContracts.Responses
{
   public record BasicInfo
   {
      public string FirstName { get; set; }
      public string LastName {get; set;}  
      public string Email {get; set;}
      public DateTime DateOfBirth {get; set;}
      public string Phone { get; set; }
      public string CurrentCity {get; set;} 
   }
}