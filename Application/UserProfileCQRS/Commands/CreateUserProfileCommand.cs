using Social.Application.Helpers;
using MediatR;
using Social.Domain.Aggregates.UserProfileAggregate;
namespace Social.Application.UserProfileCQRS.Commands
{
   public class CreateUserProfileCommand : IRequest<GenericHandlersResponse<UserProfile>>
   {
      public string FirstName { get; set; }
      public string LastName {get; set;}  
      public string Email {get; set;}
      public DateTime DateOfBirth {get; set;}
      public string Phone { get; set; }
      public string CurrentCity {get; set;}   
   }
}