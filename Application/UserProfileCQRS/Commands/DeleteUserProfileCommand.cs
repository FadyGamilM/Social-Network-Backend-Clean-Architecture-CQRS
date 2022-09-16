using MediatR;
namespace Social.Application.UserProfileCQRS.Commands
{
   public class DeleteUserProfileCommand : IRequest
   {
      public Guid ProfileId { get; set; }
   }
}