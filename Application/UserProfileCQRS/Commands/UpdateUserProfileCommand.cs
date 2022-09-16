using Social.Domain.Aggregates.UserProfileAggregate;
using MediatR;
namespace Social.Application.UserProfileCQRS.Commands
{
   // we don't need to return anything from the update command handler at now .. 
   public class UpdateUserProfileCommand : IRequest
   {
      // The id is very important to be given here when the API layer create this command, so we can specify which user 
      public Guid profileId { get; set; }
 
      // The informations that might be updated by the user
      public string FirstName { get; set; }
      public string LastName {get; set;}  
      public string Email {get; set;}
      public DateTime DateOfBirth {get; set;}
      public string Phone { get; set; }
      public string CurrentCity {get; set;}   
   }
}