using Social.Application.Helpers;
using MediatR;
using Social.Domain.Aggregates.UserProfileAggregate;
namespace Social.Application.UserProfileCQRS.Commands
{
   public class DeleteUserProfileCommand : IRequest<GenericHandlersResponse<UserProfile>>
   {
      public Guid ProfileId { get; set; }
   }
}